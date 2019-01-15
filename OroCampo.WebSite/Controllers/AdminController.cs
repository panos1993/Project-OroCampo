

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using ImageProcessor.Processors;

namespace OroCampo.WebSite.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using DatabaseHandler.Helpers;
    using OroCampo.Models.Database;
    using Models;
    using ConfigurationManager = System.Configuration.ConfigurationManager;
    using System.Collections.Generic;

    using OroCampo.WebSite.Models.Admin;

    public class AdminController : Controller
    {

        // --------Manage Methods-------

        public async Task<ActionResult> ManagementPhotoCategory(string message = null, bool success = false)
        {

            var categories = await DatabaseHelper.GetPhotoCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new PhotoCategoryModel() { PhotoCategories = categories, Message = message, Success = success });
        }

        public async Task<ActionResult> ManagementProductCategory(string message = null, bool success = false)
        {
            var categories = await DatabaseHelper.GetProductCategories(ConfigurationManager.AppSettings["ConnectionString"]);

            return View(new ProductCategoryModel() { ProductCategories = categories, Message = message, Success = success });
        }

        public async Task<ActionResult> ManagementProduct(string message = null, bool success = false, Guid? editGuid = null)
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

            ProductModel model;

            if (editGuid != null)
            {
                var editProduct = products.First(x => x.Id == editGuid.ToGuid());

                model = new ProductModel()
                {
                    Products = products,
                    Categories = listItems,
                    Message = message,
                    Success = success,

                    Name = editProduct.Name,
                    Description = editProduct.Description,
                    ProductCategoryId = editProduct.CategoryId,
                    Photo = editProduct.Photo,
                    ProductId = editGuid.ToGuid()
                };

            }
            else
            {
                model = new ProductModel()
                {
                    Products = products,
                    Categories = listItems,
                    Message = message,
                    Success = success
                };
            }

            return View(model);
        }

        public async Task<ActionResult> ManagementPhoto(string message = null, bool success = false, Guid? editGuid = null)
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
            PhotoModel model;

            if (editGuid != null)
            {
                var editPhoto = photos.First(x => x.Id == editGuid.ToGuid());

                model = new PhotoModel()
                {
                    Photos = photos,
                    Categories = listItems,
                    Message = message,
                    Success = success,

                    Title = editPhoto.Title,
                    PhotoDescription = editPhoto.Description,
                    PhotoCategoryId = editPhoto.CategoryId,
                    PhotoData = editPhoto.PhotoData,
                    Thumbnail = editPhoto.Thumbnail,
                    PhotoId = editGuid.ToGuid()
                };

            }
            else
            {
                model = new PhotoModel()
                { Photos = photos, Categories = listItems, Message = message, Success = success };
            }
            return View(model);
        }

        public async Task<ActionResult> ManagementService(string message = null, bool success = false, Guid? editGuid = null)
        {
            var services = await DatabaseHelper.GetServices(ConfigurationManager.AppSettings["ConnectionString"], true);

            ServiceModel model;

            if (editGuid != null)
            {
                var editService = services.First(x => x.Id == editGuid.ToGuid());

                model = new ServiceModel()
                {
                    Services = services,
                    Message = message,
                    Success = success,

                    NewTitleService = editService.Title,
                    NewDescriptionService = editService.Description,
                    NewPhotoService = editService.Photo,
                    ServiceId = editGuid.ToGuid()
                };
            }
            else
            {
                model = new ServiceModel()
                {
                    Services = services,
                    Message = message,
                    Success = success
                };
            }

            return View(model);
        }

        public async Task<ActionResult> ManagementBlogPost(string message = null, bool success = false, Guid? editGuid = null)
        {
            var blogPosts = await DatabaseHelper.GetBlogPosts(ConfigurationManager.AppSettings["ConnectionString"]);

            BlogPostModel model;

            if (editGuid != null)
            {
                var editBlogPost = blogPosts.First(x => x.Id == editGuid.ToGuid());

                model = new BlogPostModel()
                {
                    BlogPosts = blogPosts,
                    Message = message,
                    Success = success,
                    NewTitleBlogPost = editBlogPost.Title,
                    NewTextBlogPost = editBlogPost.Text,
                    NewPhotoBlogPost = editBlogPost.Photo,
                    BlogPostId = editGuid.ToGuid()
                };

            }
            else
            {
                model = new BlogPostModel()
                {
                    BlogPosts = blogPosts,
                    Message = message,
                    Success = success
                };
            }

            return View(model);
        }

        //--------Save Methods-------

        public async Task<ActionResult> SavePhotoCategory(PhotoCategoryModel model)
        {
            var categoryToAdd = new PhotoCategory()
            {
                Name = model.NewPhotoCategoryName
            };

            await DatabaseHelper.SavePhotoCategory(categoryToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementPhotoCategory", "Admin");
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

        [ValidateInput(false)]
        public async Task<ActionResult> SaveProduct(ProductModel model, HttpPostedFileBase file)
        {
            string imageData = null;
            if (model.ProductId != default(Guid))
            {
                var success = await UpdateProduct(model, file);
                return RedirectToAction("ManagementProduct", "Admin",
                    new { message = success ? Resourse.update_success : Resourse.something_went_wrong, success });
            }

            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
            }

            var productToAdd = new Product()
            {
                Name = model.Name,
                Description = model.Description,
                Photo = imageData,
                CategoryId = model.ProductCategoryId
            };

            await DatabaseHelper.SaveProduct(productToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementProduct", "Admin");
        }

        [ValidateInput(false)]
        public async Task<ActionResult> SavePhoto(PhotoModel model, HttpPostedFileBase file)
        {
            string imageData = null, thumbnail = null;
            
            if (model.PhotoId != default(Guid))
            {
                var success = await UpdatePhoto(model, file);
                return RedirectToAction("ManagementPhoto", "Admin",
                    new { message = success ? Resourse.update_success : Resourse.something_went_wrong, success });
            }
            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);

                thumbnail = Resize(thePictureAsBytes);
            }
            
            var photoToAdd = new Photo()
            {
                Title = model.Title,
                Description = model.PhotoDescription,
                PhotoData = imageData,
                Thumbnail = thumbnail,
                CategoryId = model.PhotoCategoryId
            };

            await DatabaseHelper.SavePhoto(photoToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementPhoto", "Admin");
        }

        private string Resize(byte[] photoBytes)
        {
            // Format is automatically detected though can be changed.
            ISupportedImageFormat format = new JpegFormat { Quality = 70 };
            Size size = new Size(150, 0);
            using (MemoryStream inStream = new MemoryStream(photoBytes))
            {
                using (MemoryStream outStream = new MemoryStream())
                {
                    // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                    using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                    {
                        // Load, resize, set the format and quality and save an image.
                        imageFactory.Load(inStream)
                            .Resize(size)
                            .Format(format)
                            .Save(outStream);
                    }
                    // Do something with the stream.
                    return Convert.ToBase64String(outStream.ToArray());
                }
            }
        }

        [ValidateInput(false)]
        public async Task<ActionResult> SaveService(ServiceModel model, HttpPostedFileBase file)
        {
            string imageData = null;
            if (model.ServiceId != default(Guid))
            {
                var success = await UpdateService(model,file);
                return RedirectToAction("ManagementService", "Admin",
                    new { message = success ? Resourse.update_success : Resourse.something_went_wrong, success });
            }

            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
            }

            var serviceToAdd = new Service()
            {
                Title = model.NewTitleService,
                Description = model.NewDescriptionService,
                Photo = imageData,
            };

            await DatabaseHelper.SaveService(serviceToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementService", "Admin");
        }

        [ValidateInput(false)]
        public async Task<ActionResult> SaveBlogPost(BlogPostModel model, HttpPostedFileBase file)
        {
            string imageData = null;
            if (model.BlogPostId != default(Guid))
            {
                var success = await UpdateBlogPost(model,file);
                return RedirectToAction("ManagementBlogPost", "Admin",
                    new { message = success ? Resourse.update_success : Resourse.something_went_wrong, success });
            }

            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
            }
            var blogPostToAdd = new BlogPost()
            {
                Title = model.NewTitleBlogPost,
                Text = model.NewTextBlogPost,
                Photo = imageData,
            };

            await DatabaseHelper.SaveBlogPost(blogPostToAdd, ConfigurationManager.AppSettings["ConnectionString"]);

            return RedirectToAction("ManagementBlogPost", "Admin");
        }

        //-------Delete Methods-------

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

        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var success =
                await DatabaseHelper.DeleteProduct(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementProduct", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public async Task<ActionResult> DeletePhoto(Guid id)
        {
            var success =
                await DatabaseHelper.DeletePhoto(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementPhoto", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public async Task<ActionResult> DeleteService(Guid id)
        {
            var success =
                await DatabaseHelper.DeleteService(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementService", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        public async Task<ActionResult> DeleteBlogPost(Guid id)
        {
            var success =
                await DatabaseHelper.DeleteBlogPost(ConfigurationManager.AppSettings["ConnectionString"], id);
            return RedirectToAction("ManagementBlogPost", "Admin",
                new { message = success ? Resourse.delete_success : Resourse.something_went_wrong, success });
        }

        //------Edit Methods------

        public async Task<ActionResult> EditProduct(Guid id)
        {
            return RedirectToAction("ManagementProduct", "Admin", new { editGuid = id });
        }

        public async Task<ActionResult> EditPhoto(Guid id)
        {
            return RedirectToAction("ManagementPhoto", "Admin", new { editGuid = id });
        }

        public async Task<ActionResult> EditService(Guid id)
        {
            return RedirectToAction("ManagementService", "Admin", new { editGuid = id });
        }

        public async Task<ActionResult> EditBlogPost(Guid id)
        {
            return RedirectToAction("ManagementBlogPost", "Admin", new { editGuid = id });
        }

        //------Update Methods-------

        public async Task<bool> UpdateProduct(ProductModel model, HttpPostedFileBase file)
        {
            string imageData = model.Photo;
            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
            }
            var productUpdate = new Product()
            {
                Name = model.Name,
                Id = model.ProductId,
                Description = model.Description,
                Photo = imageData,
                CategoryId = model.ProductCategoryId
            };

            return await DatabaseHelper.UpdateProduct(productUpdate, ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public async Task<bool> UpdatePhoto(PhotoModel model, HttpPostedFileBase file)
        {
            string imageData = model.PhotoData, thumbnail=null;
            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
                thumbnail = Resize(thePictureAsBytes);
            }
            var photoUpdate = new Photo()
            {
                Id = model.PhotoId,
                Title = model.Title,
                Description = model.PhotoDescription,
                PhotoData = imageData,
                Thumbnail = thumbnail,
                CategoryId = model.PhotoCategoryId
            };

            return await DatabaseHelper.UpdatePhoto(photoUpdate, ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public async Task<bool> UpdateService(ServiceModel model, HttpPostedFileBase file)
        {
            string imageData = model.NewPhotoService;
            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
            }
            var serviceUpdate = new Service()
            {
                Id = model.ServiceId,
                Title = model.NewTitleService,
                Description = model.NewDescriptionService,
                Photo = imageData,
            };

            return await DatabaseHelper.UpdateService(serviceUpdate, ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public async Task<bool> UpdateBlogPost(BlogPostModel model, HttpPostedFileBase file)
        {
            string imageData = model.NewPhotoBlogPost;
            if (file != null)
            {
                var theFileName = Path.GetFileName(file.FileName);
                var thePictureAsBytes = new byte[file.ContentLength];
                using (var theReader = new BinaryReader(file.InputStream))
                {
                    thePictureAsBytes = theReader.ReadBytes(file.ContentLength);
                }

                imageData = Convert.ToBase64String(thePictureAsBytes);
            }
            var blogPostUpdate = new BlogPost()
            {
                Id = model.BlogPostId,
                Title = model.NewTitleBlogPost,
                Text = model.NewTextBlogPost,
                Photo = imageData,
            };

            return await DatabaseHelper.UpdateBlogPost(blogPostUpdate, ConfigurationManager.AppSettings["ConnectionString"]);
        }

    }
}