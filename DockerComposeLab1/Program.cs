

using DockerComposeLab1.Data;
using DockerComposeLab1.Models;
using Microsoft.EntityFrameworkCore;

namespace DockerComposeLab1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ProductContext>();
                context.Database.Migrate();

                if(!context.Products.Any()) 
                {

                    context.Products.AddRange(
                        new Product { Name = "Redbull", Price = 15 },
                        new Product { Name = "Celcius", Price = 20 },
                        new Product { Name = "Monster", Price = 18 }
                        );
                    context.SaveChanges();

                }

            }

            app.MapGet("/products", async (ProductContext db) =>
       await db.Products.ToListAsync());

            app.MapGet("/products/{id}", async (ProductContext db, int id) =>
                await db.Products.FindAsync(id) is Product product
                    ? Results.Ok(product)
                    : Results.NotFound());

            app.MapPost("/products", async (ProductContext db, Product product) =>
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return Results.Created($"/products/{product.Id}", product);
            });

            app.MapPut("/products/{id}", async (ProductContext db, int id, Product updatedProduct) =>
            {
                var product = await db.Products.FindAsync(id);
                if (product is null) return Results.NotFound();

                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                await db.SaveChangesAsync();
                return Results.Ok(product);
            });

            app.MapDelete("/products/{id}", async (ProductContext db, int id) =>
            {
                var product = await db.Products.FindAsync(id);
                if (product is null) return Results.NotFound();

                db.Products.Remove(product);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });


            app.Run();
        }
    }
}
