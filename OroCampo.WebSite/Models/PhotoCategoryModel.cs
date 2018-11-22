using OroCampo.Models.Database;
using System;
using System.Collections.Generic;

namespace OroCampo.WebSite.Models
{
    public class PhotoCategoryModel
    {
        public List<PhotoCategory> PhotoCategories { get; set; }

        public string NewPhotoCategoryName { get; set; }

        public Guid? PhotoCategoryIdToDelete { get; set; }
    }
}