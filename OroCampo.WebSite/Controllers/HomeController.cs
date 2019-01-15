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

            var slidePhotoCategory = photoCategories.FirstOrDefault(x => x.Name == "slide photo");

            var id = Guid.Empty;

            if (slidePhotoCategory != null)
            {
                id = slidePhotoCategory.Id;
            }

            
            var photosSlider = await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], id);
            var teamPhotoCategory = photoCategories.FirstOrDefault(x => x.Name == "Team photo");
            if (teamPhotoCategory != null)
            {
                id = teamPhotoCategory.Id;
            }
            var photosTeam =
                await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], id,
                    true);
            var photosThumbnail = await DatabaseHelper.GetPhotos(ConfigurationManager.AppSettings["ConnectionString"], true);
            var blogPosts =
                await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"], true);
            IndexModel model = new IndexModel()
            { PhotosSlider = photosSlider, PhotosTeam = photosTeam, PhotosThumbnail = photosThumbnail, PhotoCategories = photoCategories, BlogPosts = blogPosts};

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