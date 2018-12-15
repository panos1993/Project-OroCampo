namespace OroCampo.WebSite.Models
{
    using OroCampo.Models.Database;
    using System.Collections.Generic;
    public class PhotoCategoryModel : ModelBase
    {
        public List<PhotoCategory> PhotoCategories { get; set; }

        public string NewPhotoCategoryName { get; set; }

    }
}