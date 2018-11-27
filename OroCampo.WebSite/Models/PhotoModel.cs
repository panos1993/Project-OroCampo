

namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class PhotoModel
    {
        public List<Photo> Photos { get; set; }

        public string NewPhotoData { get; set; }

        public string NewPhotoDescription { get; set; }

        public Guid PhotoCategoryId { get; set; }

        public Guid? PhotoIdToDelete { get; set; }

    }
}