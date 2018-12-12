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

                var query = "SELECT * FROM [dbo].[Product] (NOLOCK)";

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

        public static List<string> FindProductCategoryName(string connectionString, Guid? productCategoryId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                sqlConnection.Open();

                var query = "SELECT [Name] FROM [dbo].[ProductCategory] (NOLOCK) WHERE [Id] = @productCategoryId";

                var productCategory = sqlConnection.Query<string>(query, new { productCategoryId });

                sqlConnection.Close();

                return (List<string>)productCategory;
            }
        }
    }
}
