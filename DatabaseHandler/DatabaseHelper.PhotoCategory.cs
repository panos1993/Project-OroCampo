namespace OroCampo.DatabaseHandler
{
    using Dapper;
    using OroCampo.Models.Database;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class DatabaseHelper
    {
        public async Task<Guid> SaveProductCategory(PhotoCategory photoCategory, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[PhotoCategory] ([Name]) OUTPUT INSERTED.Id ";
                query += "VALUES (@name)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         name = photoCategory.Name,
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public async Task<PhotoCategory> GetPhotoCategory(Guid photoCategoryId, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[PhotoCategory] (NOLOCK) WHERE [Id] = @photoCategoryId ";

                var photoCategory = await sqlConnection.QueryFirstOrDefaultAsync<PhotoCategory>(query, new { photoCategoryId });

                sqlConnection.Close();

                return photoCategory;
            }
        }

        public async Task<List<PhotoCategory>> GetPhotoCategories(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[PhotoCategory] (NOLOCK)";

                var photoCategories = await sqlConnection.QueryAsync<PhotoCategory>(query);

                sqlConnection.Close();

                return photoCategories.ToList();
            }
        }
    }
}