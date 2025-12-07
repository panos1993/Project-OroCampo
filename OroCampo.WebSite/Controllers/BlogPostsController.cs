using System.Configuration;
using System.Threading.Tasks;
using OroCampo.DatabaseHandler.Helpers;
using OroCampo.WebSite.Models.BlogPosts;

namespace OroCampo.WebSite.Controllers
{
    using System.Web.Mvc;

    public class BlogPostsController : Controller
    {
        // GET: BlogPosts
        public async Task<ActionResult> Index()
        {
            var blogPosts =
                await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"], true);
            IndexModel model = new IndexModel()
            {
                BlogPosts = blogPosts
            };
            return View(model);
        }
    }
}