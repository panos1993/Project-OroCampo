namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;
    using System.Web.Mvc;

    public class PhotoModel : ModelBase
    {
        public List<Photo> Photos { get; set; }

        public string PhotoData { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string PhotoDescription { get; set; }

        public Guid PhotoCategoryId { get; set; }

        public Guid PhotoId { get; set; }

    }
}