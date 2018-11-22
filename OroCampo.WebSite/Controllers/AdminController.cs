using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OroCampo.DatabaseHandler.Helpers;
using OroCampo.Models.Database;
using OroCampo.WebSite.Models;

namespace OroCampo.WebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public async Task<ActionResult> Index()
        {

            var categories = await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new PhotoCategoryModel(){PhotoCategories = categories});
        }

        public async Task<ActionResult> SavePhotoCategory(PhotoCategoryModel model)
        {
            var categoryToAdd = new PhotoCategory()
            {
                Name = model.NewPhotoCategoryName
            };

            await DatabaseHelper.SavePhotoCategory(categoryToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return this.RedirectToAction("Index", "Admin");
        }
    }
}