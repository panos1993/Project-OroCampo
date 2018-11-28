
namespace OroCampo.WebSite.Models
{
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ProductCategoryModel
    {
        public List<ProductCategory> ProductCategories { get; set; }

        public string NewProductCategoryName { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}