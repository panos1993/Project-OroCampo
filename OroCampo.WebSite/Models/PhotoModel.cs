
using System.Web.Mvc;

namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class PhotoModel
    {
        public List<Photo> Photos { get; set; }

        public string PhotoData { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string PhotoDescription { get; set; }

        public Guid PhotoCategoryId { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }

    }
}