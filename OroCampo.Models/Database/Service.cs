namespace OroCampo.Models.Database
{
    using System;

    public class Service
    {
        public Guid Id { get; set; }
        
        public string Title { get; set; }
        
        public string Description { get; set; }

        public string Photo { get; set; }

        public DateTime DateTime { get; set; }
    }
}
