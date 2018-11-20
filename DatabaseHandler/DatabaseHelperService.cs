

namespace OroCampo.DatabaseHandler
{
    using Dapper;
    using OroCampo.Models.Database;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    public class DatabaseHelperService
    {
        public async Task<Guid> SaveService(Service service, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[Product] ([DateTime], [Title], [Description], [Photo], OUTPUT INSERTED.Id ";
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

        public async Task<Service> GetService(Guid serviceId, string connectionString)
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

        public async Task<List<Service>> GetServices(string connectionString)
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
    }
}
