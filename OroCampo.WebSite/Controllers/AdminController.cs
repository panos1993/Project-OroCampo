

using System;
using System.IO;
using System.Web;

namespace OroCampo.WebSite.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DatabaseHandler.Helpers;
    using OroCampo.Models.Database;
    using Models;
    using ConfigurationManager = System.Configuration.ConfigurationManager;
    using System.Collections.Generic;

    public class AdminController : Controller
    {
        // GET: Admin
        public async Task<ActionResult> ManagementPhotoCategory(string message = null, bool success = false)
        {

            var categories = await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new PhotoCategoryModel() { PhotoCategories = categories, Message = message, Success = success });
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

        public async Task<ActionResult> ManagementProductCategory(string message = null, bool success = false)
        {
            var categories = await DatabaseHelper.GetProductCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ProductCategoryModel() { ProductCategories = categories, Message = message, Success = success });
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

        public async Task<ActionResult> ManagementProduct(string message = null, bool success = false)
        {
            var products = await DatabaseHelper.GetProducts(ConfigurationManager.AppSettings["ConnectionString"]);

            var categories =
                await DatabaseHelper.GetProductCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            var listItems = new List<SelectListItem>();

            foreach (var productCategory in categories)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = productCategory.Name,
                    Value = productCategory.Id.ToString()
                });
            }

            return View(new ProductModel() { Products = products, Categories = listItems, Message = message, Success = success });
        }

        public async Task<ActionResult> ManagementPhoto(string message = null, bool success = false)
        {
            var photos = await DatabaseHelper.GetPhotos(ConfigurationManager.AppSettings["ConnectionString"]);

            var categories =
                await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            var listItems = new List<SelectListItem>();

            foreach (var photoCategory in categories)
            {
                listItems.Add(new SelectListItem()
                {
                    Text = photoCategory.Name,
                    Value = photoCategory.Id.ToString()
                });
            }

            return View(new PhotoModel() { Photos = photos, Categories = listItems, Message = message, Success = success });
        }

        public async Task<ActionResult> SavePhoto(PhotoModel model, HttpPostedFileBase file)
        {
            var theFileName = Path.GetFileName(file.FileName);
            var thePictureAsBytes = new byte[file.ContentLength];
            using (var theReader = new BinaryReader(file.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
            }
            var thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);

            var photoToAdd = new Photo()
            {
                Description = model.PhotoDescription,
                PhotoData = thePictureDataAsString,
                CategoryId = model.PhotoCategoryId
            };

            await DatabaseHelper.SavePhoto(photoToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementPhoto", "Admin");
        }

        public async Task<ActionResult> ManagementService(string message = null, bool success = false)
        {
            var services = await DatabaseHelper.GetServices(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ServiceModel() { Services = services, Message = message,Success = success});
        }

        public async Task<ActionResult> ManagementBlogPost(string message = null, bool success = false)
        {
            var blogPosts = await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new BlogPostModel() { BlogPosts = blogPosts, Message = message, Success = success });
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

            return RedirectToAction("ManagementProductCategory", "Admin", new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public async Task<ActionResult> DeletePhotoCategory(Guid id)
        {
            var existingPhotos =
                await DatabaseHelper.GetPhotosByCategoryId(ConfigurationManager.AppSettings["ConnectionString"], id);
            if (existingPhotos.Count > 0)
            {
                return RedirectToAction("ManagementPhotoCategory", "Admin",
                    new { message = Resourse.photo_category_unable_to_delete_existing_photos });
            }

            var success =
                await DatabaseHelper.DeletePhotoCategory(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementPhotoCategory", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public async Task<ActionResult> SaveProduct(ProductModel model, HttpPostedFileBase file)
        {
            var theFileName = Path.GetFileName(file.FileName);
            var thePictureAsBytes = new byte[file.ContentLength];
            using (var theReader = new BinaryReader(file.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
            }
            var thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);

            var productToAdd = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Photo = thePictureDataAsString,
                CategoryId = model.ProductCategoryId
            };

            await DatabaseHelper.SaveProduct(productToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementProduct", "Admin");
        }

        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var success =
                await DatabaseHelper.DeleteProduct(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementProduct", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public List<string> FindProductCategoryName(Guid? id)
        {
            var categoryName = DatabaseHelper.FindProductCategoryName(ConfigurationManager.AppSettings["ConnectionString"], id);
            return categoryName;
        }

        public async Task<ActionResult> DeletePhoto(Guid id)
        {
            var success =
                await DatabaseHelper.DeletePhoto(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementPhoto", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public List<string> FindPhotoCategoryName(Guid? id)
        {
            var categoryName = DatabaseHelper.FindPhotoCategoryName(ConfigurationManager.AppSettings["ConnectionString"], id);
            return categoryName;
        }

        public async Task<ActionResult> SaveService(ServiceModel model, HttpPostedFileBase file)
        {
            var theFileName = Path.GetFileName(file.FileName);
            var thePictureAsBytes = new byte[file.ContentLength];
            using (var theReader = new BinaryReader(file.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
            }
            var thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);

            var serviceToAdd = new Service()
            {
                Title = model.NewTitleService,
                Description = model.NewDescriptionService,
                Photo = thePictureDataAsString,
            };

            await DatabaseHelper.SaveService(serviceToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementService", "Admin");
        }

        public async Task<ActionResult> DeleteService(Guid id)
        {
            var success =
                await DatabaseHelper.DeleteService(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementService", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public async Task<ActionResult> SaveBlogPost(BlogPostModel model, HttpPostedFileBase file)
        {
            var theFileName = Path.GetFileName(file.FileName);
            var thePictureAsBytes = new byte[file.ContentLength];
            using (var theReader = new BinaryReader(file.InputStream))
            {
                thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
            }
            var thePictureDataAsString = Convert.ToBase64String(thePictureAsBytes);

            var blogPostToAdd = new BlogPost()
            {
                Title = model.NewTitleBlogPost,
                Text = model.NewTextBlogPost,
                Photo = thePictureDataAsString,
            };

            await DatabaseHelper.SaveBlogPost(blogPostToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementBlogPost", "Admin");
        }

        public async Task<ActionResult> DeleteBlogPost(Guid id)
        {
            var success =
                await DatabaseHelper.DeleteBlogPost(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementBlogPost", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }


    }
}