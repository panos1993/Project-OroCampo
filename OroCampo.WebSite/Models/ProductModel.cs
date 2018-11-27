
namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ProductModel
    {
        public List<Product> Products { get; set; }

        public string NewProductName { get; set; }

        public string NewProductDescription { get; set; }

        public string NewProductPhoto { get; set; }

        public Guid ProductCategoryId { get; set; }

        public Guid? ProductIdToDelete { get; set; }
    }
}