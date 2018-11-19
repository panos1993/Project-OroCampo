namespace OroCampo.DatabaseHandler
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
         public async Task<Guid> SaveBlogPost(BlogPost blogPost, string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query =
                    "INSERT INTO [dbo].[BlogPost] ([DateTime], [Title], [Text], [Photo]) OUTPUT INSERTED.Id ";
                query += "VALUES (GETDATE(), @title, @text, @photo, @categoryId, @text)";

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

        public async Task<BlogPost> GetBlogPost(Guid blogPostId, string connectionString)
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

        public async Task<List<BlogPost>> GetBlogPosts(string connectionString)
        {
            // We create an sql connection 
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                // Open the connection async
                await sqlConnection.OpenAsync();

                var query = "SELECT * FROM [dbo].[BlogPost] (NOLOCK)";

                var blogPosts = await sqlConnection.QueryAsync<BlogPost>(query);

                sqlConnection.Close();

                return blogPosts.ToList();
            }
        }
    }
}
