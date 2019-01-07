namespace OroCampo.WebSite.Models.Home
{
    using OroCampo.Models.Database;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class indexModel
    {
        public List<Photo> Photos { get; set; }

        public string PhotoData { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string PhotoDescription { get; set; }

        public Guid PhotoCategoryId { get; set; }

        public Guid PhotoId { get; set; }
    }
}