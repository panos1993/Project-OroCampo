
using System.Web.Mvc;

namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ProductModel
    {
        public List<Product> Products { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public Guid ProductCategoryId { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}