namespace OroCampo.WebSite.Models
{
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class BlogPostModel : ModelBase
    {
        public List<BlogPost> BlogPosts { get; set; }

        public string NewPhotoBlogPost { get; set; }

        public string NewTitleBlogPost { get; set; }

        public string NewTextBlogPost { get; set; }

    }
}