namespace OroCampo.DatabaseHandler.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Models.Database;

    public partial class DatabaseHelper
    {
        public static async Task<Guid> SavePhoto(Photo photo, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[Photo] ([DateTime], [PhotoData], [Description], [CategoryId]) OUTPUT INSERTED.Id ";
                query += "VALUES (GETDATE(), @photoData, @description, @categoryId)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         photoData = photo.PhotoData,
                                         description = photo.Description,
                                         categoryId = photo.CategoryId
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public static async Task<Photo> GetPhoto(Guid photoId, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Photo] (NOLOCK) WHERE [Id] = @photoId ";

                var photo = await sqlConnection.QueryFirstOrDefaultAsync<Photo>(query, new { photoId });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return photo;
            }
        }

        public static async Task<List<Photo>> GetPhotos(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT P.*, PC.Name AS PhotoCategoryName FROM [dbo].[Photo] AS P, [dbo].[PhotoCategory] AS PC (NOLOCK) WHERE P.CategoryId = PC.Id";

                var photos = await sqlConnection.QueryAsync<Photo>(query);

                sqlConnection.Close();

                return photos.ToList();
            }
        }

        public static async Task<List<Photo>> GetPhotosByCategoryId(string connectionString, Guid photoCategoryId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Photo] (NOLOCK) WHERE [CategoryId] = @photoCategoryId";

                var photos = await sqlConnection.QueryAsync<Photo>(query, new { photoCategoryId });

                sqlConnection.Close();

                return photos.ToList();
            }
        }

        public static async Task<bool> DeletePhotoCategory(string connectionString, Guid photoCategoryId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "DELETE FROM [dbo].[PhotoCategory] WHERE [Id] = @photoCategoryId";

                var deletedRows = await sqlConnection.ExecuteAsync(query, new { photoCategoryId });

                sqlConnection.Close();

                return deletedRows == 1;
            }
        }

        public static async Task<bool> DeletePhoto(string connectionString, Guid photoId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "DELETE FROM [dbo].[Photo] WHERE [Id] = @photoId";

                var deletedRows = await sqlConnection.ExecuteAsync(query, new { photoId });

                sqlConnection.Close();

                return deletedRows == 1;
            }
        }

        public static async Task<bool> UpdatePhoto(Photo photo, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                // Open the connection async
                await sqlConnection.OpenAsync();
                command.CommandText=
                    "UPDATE [dbo].[Photo] " +
                    "SET [PhotoData] = @photoData, [Description] = @description, [CategoryId]= @catId " +
                    "WHERE [Id] = @id";

                command.Parameters.AddWithValue("@photoData", photo.PhotoData);
                command.Parameters.AddWithValue("@description", photo.Description);
                command.Parameters.AddWithValue("@catId", photo.CategoryId);
                command.Parameters.AddWithValue("@id", photo.Id);
                await command.ExecuteNonQueryAsync();


                sqlConnection.Close();

                return true;
            }
        }

    }
}

