

namespace OroCampo.WebSite.Models
{
    using OroCampo.Models.Database;
    using System;
    using System.Collections.Generic;
    public class PhotoCategoryModel
    {
        public List<PhotoCategory> PhotoCategories { get; set; }

        public string NewPhotoCategoryName { get; set; }

        public string Message { get; set; }

        public bool Success { get; set; }
    }
}