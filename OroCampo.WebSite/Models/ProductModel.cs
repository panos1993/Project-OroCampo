namespace OroCampo.WebSite.Models
{
    using System.Web.Mvc;
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ProductModel : ModelBase 
    {
        public List<Product> Products { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public Guid ProductCategoryId { get; set; }

        public Guid ProductId { get; set; }

    }
}