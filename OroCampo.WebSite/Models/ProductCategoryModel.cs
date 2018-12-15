namespace OroCampo.WebSite.Models
{
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ProductCategoryModel : ModelBase
    {
        public List<ProductCategory> ProductCategories { get; set; }

        public string NewProductCategoryName { get; set; }

    }
}