namespace OroCampo.DatabaseHandler.Helpers
{
    using Models.Database;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DatabaseHelper
    {
        public static async Task<Guid> SaveProduct(Product product, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[Product] ([DateTime], [Name], [Description], [Photo], [CategoryId]) OUTPUT INSERTED.Id ";
                query += "VALUES (GETDATE(), @name, @description, @photo, @categoryId)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         name = product.Name,
                                         description = product.Description,
                                         photo = product.Photo,
                                         categoryId = product.CategoryId
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public static async Task<Product> GetProduct(Guid productId, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Product] (NOLOCK) WHERE [Id] = @productId ";

                var product = await sqlConnection.QueryFirstOrDefaultAsync<Product>(query, new { productId });

                sqlConnection.Close();

                return product;
            }
        }

        public static async Task<List<Product>> GetProducts(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT P.*, PC.Name AS ProductCategoryName FROM [dbo].[Product] AS P, [dbo].[ProductCategory] AS PC (NOLOCK) WHERE P.CategoryId = PC.Id";

                var products = await sqlConnection.QueryAsync<Product>(query);

                sqlConnection.Close();

                return products.ToList();
            }
        }

        public static async Task<List<Product>> GetProductsByCategoryId(string connectionString, Guid productCategoryId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Product] (NOLOCK) WHERE [CategoryId] = @productCategoryId";

                var products = await sqlConnection.QueryAsync<Product>(query, new { productCategoryId });

                sqlConnection.Close();

                return products.ToList();
            }
        }

        public static async Task<bool> DeleteProduct(string connectionString, Guid productId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "DELETE FROM [dbo].[Product] WHERE [Id] = @productId";

                var deletedRows = await sqlConnection.ExecuteAsync(query, new { productId });

                sqlConnection.Close();

                return deletedRows == 1;
            }
        }

        public static async Task<bool> UpdateProduct(Product product, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                // Open the connection async
                await sqlConnection.OpenAsync();
                command.CommandText =
                    "UPDATE [dbo].[Product] " +
                    "SET [Name] = @name, [Description] = @description, [Photo] = @photo, [CategoryId]= @catId " +
                    "WHERE [Id] = @id";

                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@photo", product.Photo);
                command.Parameters.AddWithValue("@catId", product.CategoryId);
                command.Parameters.AddWithValue("@id", product.Id);
                await command.ExecuteNonQueryAsync();

                sqlConnection.Close();

                return true;
            }
        }

    }
}
