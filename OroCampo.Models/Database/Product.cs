namespace OroCampo.Models.Database
{
    using System;

    public class Product
    {
        public Guid Id { get; set; }

        public string ProductCategoryName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public DateTime DateTime { get; set; }

        public Guid CategoryId { get; set; }
    }
}
