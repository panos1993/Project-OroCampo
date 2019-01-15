namespace OroCampo.WebSite.Models.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    using OroCampo.Models.Database;

    public class PhotoModel : ModelBase
    {
        public List<Photo> Photos { get; set; }

        public string PhotoData { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string Title { get; set; }

        public string Thumbnail { get; set; }

        public string PhotoDescription { get; set; }

        public Guid PhotoCategoryId { get; set; }

        public Guid PhotoId { get; set; }

    }
}