﻿namespace OroCampo.DatabaseHandler.Helpers
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
        public static async Task<Guid> SaveService(Service service, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[Service] ([DateTime], [Title], [Description], [Photo]) OUTPUT INSERTED.Id ";
                query += "VALUES (GETDATE(), @title, @description, @photo)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         title = service.Title,
                                         description = service.Description,
                                         photo = service.Photo
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public static async Task<Service> GetService(Guid serviceId, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Service] (NOLOCK) WHERE [Id] = @servicetId ";

                var service = await sqlConnection.QueryFirstOrDefaultAsync<Service>(query, new { serviceId });

                sqlConnection.Close();

                return service;
            }
        }

        public static async Task<List<Service>> GetServices(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[Service] (NOLOCK)";

                var services = await sqlConnection.QueryAsync<Service>(query);

                sqlConnection.Close();

                return services.ToList();
            }
        }

        public static async Task<bool> DeleteService(string connectionString, Guid serviceId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "DELETE FROM [dbo].[Service] WHERE [Id] = @serviceId";

                var deletedRows = await sqlConnection.ExecuteAsync(query, new { serviceId });

                sqlConnection.Close();

                return deletedRows == 1;
            }
        }

        public static async Task<bool> UpdateService(Service service, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                // Open the connection async
                await sqlConnection.OpenAsync();
                command.CommandText =
                    "UPDATE [dbo].[Service] " +
                    "SET [Title] = @title, [Description] = @description, [Photo]= @photo " +
                    "WHERE [Id] = @id";

                command.Parameters.AddWithValue("@title", service.Title);
                command.Parameters.AddWithValue("@description", service.Description);
                command.Parameters.AddWithValue("@photo", service.Photo);
                command.Parameters.AddWithValue("@id", service.Id);
                await command.ExecuteNonQueryAsync();


                sqlConnection.Close();

                return true;
            }
        }
    }
}
