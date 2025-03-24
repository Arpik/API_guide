# Flower Store API 🌸

This API allows you to manage a collection of flowers, providing functionalities to add, update, delete, and retrieve flowers from a connected database.

## Features 🚀

- **Retrieve Flowers**: Fetch a list of all available flowers.  
- **Add Flower**: Add a new flower with a name, color, and price.  
- **Update Flower**: Update the details of an existing flower.  
- **Delete Flower**: Remove a flower by its ID.  

## Endpoints 🌐

- **GET /api/flowers**  
  - Retrieves all flowers.  

- **POST /api/flowers**  
  - Adds a new flower.  
  - Request body (JSON):  
    ```json
    {
      "name": "Rose",
      "color": "Red",
      "price": 5.99
    }
    ```
    
- **PUT /api/flowers/{id}**  
  - Updates an existing flower by ID.  
  - Request body (JSON):  
    ```json
    {
      "id": 1,
      "name": "Tulip",
      "color": "Yellow",
      "price": 3.49
    }
    ```
    
- **DELETE /api/flowers/{id}**  
  - Deletes a flower by ID.  

## Prerequisites 🛠️

- .NET 6.0 or later  
- SQL Server (or any configured database)  

## Setup ⚙️

1. Clone the repository:  
    ```bash
    git clone https://github.com/yourusername/FlowerStoreAPI.git
    cd FlowerStoreAPI
    ```
2. Configure the database connection string in `appsettings.json`.  
3. Apply database migrations:  
    ```bash
    dotnet ef database update
    ```
4. Run the API:  
    ```bash
    dotnet run
    ```
5. Access the API at `http://localhost:5116/swagger` for testing.  

## Tools Used 🧰

- ASP.NET Core  
- Entity Framework Core  
- SQL Server  
