namespace OroCampo.DatabaseHandler.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using OroCampo.Models.Database;

    public partial class DatabaseHelper
    {
         public static async Task<Guid> SaveBlogPost(BlogPost blogPost, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[BlogPost] ([DateTime], [Title], [Text], [Photo]) OUTPUT INSERTED.Id ";
                query += "VALUES (GETDATE(), @title, @text, @photo)";

                var insertedId = await sqlConnection.QuerySingleAsync<Guid>(
                                     query,
                                     new
                                     {
                                         title = blogPost.Title,
                                         photo = blogPost.Photo,
                                         text = blogPost.Text
                                     });

                // Close the connection with database
                sqlConnection.Close();

                // Return id
                return insertedId;
            }
        }

        public static async Task<BlogPost> GetBlogPost(Guid blogPostId, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[BlogPost] (NOLOCK) WHERE [Id] = @blogPostId";

                var blogPost = await sqlConnection.QueryFirstOrDefaultAsync<BlogPost>(query, new { blogPostId });

                sqlConnection.Close();

                return blogPost;
            }
        }

        public static async Task<List<BlogPost>> GetBlogPosts(string connectionString, bool numberOfRecordsWeWantToReturn = false)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT TOP (2) * FROM [dbo].[BlogPost] (NOLOCK)";

                var blogPosts = await sqlConnection.QueryAsync<BlogPost>(query);

                sqlConnection.Close();

                return blogPosts.ToList();
            }
        }

        public static async Task<bool> DeleteBlogPost(string connectionString, Guid blogPostId)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "DELETE FROM [dbo].[BlogPost] WHERE [Id] = @blogPostId";

                var deletedRows = await sqlConnection.ExecuteAsync(query, new { blogPostId });

                sqlConnection.Close();

                return deletedRows == 1;
            }
        }

        public static async Task<bool> UpdateBlogPost(BlogPost blogPost, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                // Open the connection async
                await sqlConnection.OpenAsync();
                command.CommandText =
                    "UPDATE [dbo].[BlogPost] " +
                    "SET [Title] = @title, [Text] = @text, [Photo]= @photo " +
                    "WHERE [Id] = @id";

                command.Parameters.AddWithValue("@title", blogPost.Title);
                command.Parameters.AddWithValue("@text", blogPost.Text);
                command.Parameters.AddWithValue("@photo", blogPost.Photo);
                command.Parameters.AddWithValue("@id", blogPost.Id);
                await command.ExecuteNonQueryAsync();

                sqlConnection.Close();

                return true;
            }
        }
    }
}
