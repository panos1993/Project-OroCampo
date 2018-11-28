

using System;

namespace OroCampo.WebSite.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DatabaseHandler.Helpers;
    using OroCampo.Models.Database;
    using Models;
    using ConfigurationManager = System.Configuration.ConfigurationManager;
    public class AdminController : Controller
    {
        // GET: Admin
        public async Task<ActionResult> ManagementPhotoCategory(string message = null, bool success = false)
        {

            var categories = await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new PhotoCategoryModel() { PhotoCategories = categories, Message = message, Success  = success});
        }

        public async Task<ActionResult> SavePhotoCategory(PhotoCategoryModel model)
        {
            var categoryToAdd = new PhotoCategory()
            {
                Name = model.NewPhotoCategoryName
            };

            await DatabaseHelper.SavePhotoCategory(categoryToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementPhotoCategory", "Admin");
        }

        public async Task<ActionResult> ManagementProductCategory(string message = null, bool success=false)
        {
            var categories = await DatabaseHelper.GetProductCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ProductCategoryModel() { ProductCategories = categories, Message = message, Success = success});
        }

        public async Task<ActionResult> SaveProductCategory(ProductCategoryModel model)
        {
            var categoryToAdd = new ProductCategory()
            {
                Name = model.NewProductCategoryName
            };

            await DatabaseHelper.SaveProductCategory(categoryToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementProductCategory", "Admin");
        }

        public async Task<ActionResult> ManagementProduct()
        {
            var products = await DatabaseHelper.GetProducts(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ProductModel() { Products = products });
        }

        public async Task<ActionResult> ManagementPhoto()
        {
            var photos = await DatabaseHelper.GetPhotos(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new PhotoModel() { Photos = photos });
        }

        public ActionResult SavePhoto()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> ManagementService()
        {
            var services = await DatabaseHelper.GetServices(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ServiceModel() { Services = services });
        }

        public async Task<ActionResult> ManagementBlogPost()
        {
            var blogPosts = await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new BlogPostModel() { BlogPosts = blogPosts });
        }

        public async Task<ActionResult> DeleteProductCategory(Guid id)
        {
            var existingProducts =
                await DatabaseHelper.GetProductsByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], id);
            if (existingProducts.Count > 0)
            {
                return RedirectToAction("ManagementProductCategory", "Admin", new { message = Resourse.product_category_unable_to_delete_existing_products });
            }

            var success = await DatabaseHelper.DeleteProductCategory(ConfigurationManager.AppSettings["ConnectionString"], id);

            return RedirectToAction("ManagementProductCategory", "Admin", new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success});
        }

        public async Task<ActionResult> DeletePhotoCategory(Guid id)
        {
            var existingPhotos =
                await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], id);
            if (existingPhotos.Count > 0)
            {
                return RedirectToAction("ManagementPhotoCategory", "Admin",
                    new {message = Resourse.photo_category_unable_to_delete_existing_photos});
            }

            var success =
                await DatabaseHelper.DeletePhotoCategory(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementPhotoCategory", "Admin",
                new {message = success ? Resourse.delete_success : Resourse.something_went_wrong, success});
        }
    }
}