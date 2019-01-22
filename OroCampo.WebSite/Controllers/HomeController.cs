using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OroCampo.WebSite.Controllers
{

    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DatabaseHandler.Helpers;
    using OroCampo.Models.Database;
    using Models;
    using ConfigurationManager = System.Configuration.ConfigurationManager;
    using System.Collections.Generic;

    using OroCampo.WebSite.Models.Home;

    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var photoCategories = await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            var photosSlider = await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], new Guid("BB47EA25-4413-E911-9F2A-000D3AB1BD24"));
            
            var photosTeam =
                    await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], new Guid("FF3A683D-0618-E911-9F2A-000D3AB1BD24"), true);

            var aboutUsFirst = await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], new Guid("36A2AAB4-441E-E911-9F2A-000D3AB1BAFC"));

            var photosThumbnail = await DatabaseHelper.GetPhotos(ConfigurationManager.AppSettings["ConnectionString"], true);

            var blogPosts =
                await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"], true);
            IndexModel model = new IndexModel()
            { PhotosSlider = photosSlider, PhotosTeam = photosTeam, PhotosThumbnail = photosThumbnail, PhotoCategories = photoCategories, AboutUsFirst = aboutUsFirst, BlogPosts = blogPosts};

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}