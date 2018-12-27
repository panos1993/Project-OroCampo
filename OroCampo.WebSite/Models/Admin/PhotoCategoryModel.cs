namespace OroCampo.WebSite.Models.Admin
{
    using System.Collections.Generic;

    using OroCampo.Models.Database;

    public class PhotoCategoryModel : ModelBase
    {
        public List<PhotoCategory> PhotoCategories { get; set; }

        public string NewPhotoCategoryName { get; set; }

    }
}