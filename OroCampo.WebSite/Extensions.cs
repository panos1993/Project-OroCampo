using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OroCampo.WebSite
{
    public static class Extensions
    {
        public static Guid ToGuid(this Guid? source)
        {
            return source ?? Guid.Empty;
        }
    }
}