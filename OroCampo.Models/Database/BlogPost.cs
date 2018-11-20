namespace OroCampo.Models.Database
{
    using System;

    public class BlogPost
    {
        public Guid Id { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }
    }
}