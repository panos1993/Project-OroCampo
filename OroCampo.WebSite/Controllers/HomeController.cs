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
            var photos = await DatabaseHelper.GetPhotos(ConfigurationManager.AppSettings["ConnectionString"]);
            var categories = await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);
            var listItems = new List<SelectListItem>();

            foreach (var photoCategory in categories)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = photoCategory.Name,
                    Value = photoCategory.Id.ToString()
                });
            }
            indexModel model = new indexModel()
                { Photos = photos, Categories = listItems};
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