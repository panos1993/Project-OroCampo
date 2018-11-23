

namespace OroCampo.WebSite.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using OroCampo.DatabaseHandler.Helpers;
    using OroCampo.Models.Database;
    using OroCampo.WebSite.Models;
    using ConfigurationManager = System.Configuration.ConfigurationManager;
    public class AdminController : Controller
    {
        // GET: Admin
        public async Task<ActionResult> ManagementPhotoCategory()
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

            return this.RedirectToAction("ManagementPhotoCategory", "Admin");
        }

        public async Task<ActionResult> ManagementProductCategory()
        {
            var categories = await DatabaseHelper.GetProductCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ProductCategoryModel() {ProductCategories = categories});
        }

        public async Task<ActionResult> SaveProductCategory(ProductCategoryModel model)
        {
            var categoryToAdd = new ProductCategory()
            {
                Name = model.NewProductCategoryName
            };

            await DatabaseHelper.SaveProductCategory(categoryToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return this.RedirectToAction("ManagementProductCategory", "Admin");
        }

        public async Task<ActionResult> ManagementProduct()
        {
            var products = await DatabaseHelper.GetProducts(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ProductModel() {Products = products});
        }

        public async Task<ActionResult> ManagementPhoto()
        {
            var photos = await DatabaseHelper.GetPhotos(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new PhotoModel() {Photos = photos});
        }

        public ActionResult SavePhoto()
        {
            throw new System.NotImplementedException();
        }

        public async Task<ActionResult> ManagementService()
        {
            var services = await DatabaseHelper.GetServices(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ServiceModel() {Services = services});
        }

        public async Task<ActionResult> ManagementBlogPost()
        {
            var blogPosts = await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new BlogPostModel() {BlogPosts = blogPosts});
        }

        
    }
}