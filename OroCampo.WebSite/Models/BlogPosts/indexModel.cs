using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OroCampo.WebSite.Models.BlogPosts
{
    using OroCampo.Models.Database;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class IndexModel
    {
        public List<BlogPost> BlogPosts { get; set; }
    }
}