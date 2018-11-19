namespace OroCampo.DatabaseHandler
{
    using OroCampo.Models.Database;
    using System;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    using System.Collections.Generic;
    using System.Linq;

    public partial class DatabaseHelper
    {
        public async Task<Guid> SaveProduct(Product product, string connectionString)
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
                                         name =product.Name,
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

        public async Task<Product> GetProduct(Guid productId, string connectionString)
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

        public async Task<List<Product>> GetProducts(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Product] (NOLOCK)";

                var products = await sqlConnection.QueryAsync<Product>(query);

                sqlConnection.Close();

                return products.ToList();
            }
        }
    }
}
