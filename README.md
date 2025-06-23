# Product API with .NET 8, Docker, and SQL Server

## Overview

This project is a lightweight web API built using .NET 8, designed to manage product data stored in a SQL Server database. It leverages Entity Framework Core for seamless database interactions and is fully containerized using Docker and Docker Compose for easy deployment and scalability.

## Features

* Full CRUD Operations: Create, read, update, and delete products via a RESTful API.

* Containerized Setup: Runs the application and SQL Server in isolated Docker containers.

* Configuration Management: Uses appsettings.json for database connection strings and logging settings.

* Developer-Friendly: Includes a Swagger UI for easy API testing.

## Prerequisites

Before running the application, ensure you have:


* Docker Desktop installed on your system.

* Docker Compose (included with Docker Desktop).


## Setup and Running the Application

Follow these steps to get the application up and running:

1. Clone the Repository
Clone this repository to your local machine and navigate to the project root directory.


2. Build and Run with Docker Compose
In the terminal, run the following command from the project root (where docker-compose.yml is located): docker-compose up --build

This command builds the .NET application and starts both the web API and SQL Server containers.

3. Access the API
Once the containers are running, open a browser and visit:

* http://localhost:8081/swagger to access the Swagger UI for testing the API.
Alternatively, use tools like Postman or curl to interact with the endpoints.


## Technical choices

### Framework and Tools

* .NET 8 (ASP.NET Core)

* Entity Framework Core

* SQL Server

* Docker & Docker Compose

### Project Structure

* API

* Dockerfile

* docker-compose.yml

* appsettings.json

## Configuration Notes

* The database connection string is defined in appsettings.json to connect the API to the SQL Server container.

* Logging is configured to provide appropriate levels of detail for debugging and monitoring.

* The Docker Compose setup ensures that the application and database containers communicate seamlessly.

## Testing the API

Use the Swagger UI at http://localhost:8081/swagger to explore and test the API endpoints. Example endpoints include:



* GET /products: Retrieve all products.



* GET /products/{id}: Retrieve a specific product by ID.



* POST /products: Create a new product.



* PUT /products/{id}: Update an existing product.



* DELETE /products/{id}: Delete a product.

This setup provides a straightforward way to develop, test, and deploy a .NET-based product management API in a containerized environment.
