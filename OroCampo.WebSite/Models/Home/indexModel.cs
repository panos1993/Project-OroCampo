namespace OroCampo.WebSite.Models.Home
{
    using OroCampo.Models.Database;
    using System.Collections.Generic;

    public class IndexModel
    {
        public List<Photo> PhotosSlider { get; set; }

        public List<PhotoCategory> PhotoCategories { get; set; }

        public List<Photo> AboutUsFirst { get; set; }

        public List<BlogPost> BlogPosts { get; set; }

        public List<Photo> PhotosTeam { get; set; }

        public List<Photo> PhotosThumbnail { get; set; }


    }
}