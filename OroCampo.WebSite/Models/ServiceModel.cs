namespace OroCampo.WebSite.Models
{
    using System;
    using System.Collections.Generic;
    using OroCampo.Models.Database;

    public class ServiceModel
    {
        public List<Service> Services { get; set; }

        public string NewTitleService { get; set; }

        public string NewDescriptionService { get; set; }

        public string NewPhotoService {get; set; }

        public Guid? ServiceIdToDelete { get; set; }
        
        public string Message { get; set; }

        public bool Success { get; set; }
    }
}