namespace OroCampo.Models.Database
{
    using System;

    public class Photo
    {
        public Guid Id { get; set; }

        public string PhotoString { get; set; }

        public string Description { get; set; }

        public DateTime DateTime { get; set; }

        public Guid CategoryId { get; set; }
    }
}
