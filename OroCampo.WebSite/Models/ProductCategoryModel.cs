
namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ProductCategoryModel
    {
        public List<ProductCategory> ProductCategories { get; set; }

        public string NewProductCategoryName { get; set; }

        public Guid? ProductCategoryIdToDelete { get; set; }
    }
}