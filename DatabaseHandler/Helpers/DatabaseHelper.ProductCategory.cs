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
        public static async Task<Guid> SaveProductCategory(ProductCategory productCategory, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[ProductCategory] ([Name]) OUTPUT INSERTED.Id ";
                query += "VALUES (@name)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         name = productCategory.Name,
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public static async Task<ProductCategory> GetProductCategory(Guid productCategoryId, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[ProductCategory] (NOLOCK) WHERE [Id] = @productCategoryId ";

                var productCategory = await sqlConnection.QueryFirstOrDefaultAsync<ProductCategory>(query, new { productCategoryId });

                sqlConnection.Close();

                return productCategory;
            }
        }

        public static async Task<List<ProductCategory>> GetProductCategories(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[ProductCategory] (NOLOCK)";

                var productCategories = await sqlConnection.QueryAsync<ProductCategory>(query);

                sqlConnection.Close();

                return productCategories.ToList();
            }
        }

        public static async Task<bool> DeleteProductCategory(string connectionString, Guid productCategoryId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "DELETE FROM [dbo].[ProductCategory] WHERE [Id] = @productCategoryId";

                var deletedRows = await sqlConnection.ExecuteAsync(query, new { productCategoryId });

                sqlConnection.Close();

                return deletedRows == 1;
            }
        }
    }
}
