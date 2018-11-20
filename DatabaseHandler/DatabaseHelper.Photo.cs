﻿namespace OroCampo.DatabaseHandler
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
        public async Task<Guid> SavePhoto(Photo photo, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[Photo] ([DateTime], [Photo], [Description], [CategoryId]) OUTPUT INSERTED.Id ";
                query += "VALUES (GETDATE(), @photo, @description, @categoryId)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         photo = photo.PhotoString,
                                         description = photo.Description,
                                         categoryId = photo.CategoryId
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public async Task<Photo> GetPhoto(Guid photoId, string connectionString)
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

        public async Task<List<Photo>> GetPhotos(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Photo] (NOLOCK)";

                var photos = await sqlConnection.QueryAsync<Photo>(query);

                sqlConnection.Close();

                return photos.ToList();
            }
        }
    }
}
