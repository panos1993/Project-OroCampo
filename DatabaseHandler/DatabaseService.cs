using OroCampo.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OroCampo.DatabaseHandler
{
    public class DatabaseService
    {
        public static async Task<Guid> AddPhotoToDatabase(Photo photo, string connectionString, string photoCategoryName = null)
        {
            if (photoCategoryName == null)
            {
                return await Helpers.DatabaseHelper.SavePhoto(photo, connectionString);
            }

            var categoryToBeInserted = new PhotoCategory()
            {
                Name = photoCategoryName
            };

            var categoryId = await Helpers.DatabaseHelper.SavePhotoCategory(categoryToBeInserted, connectionString);

            photo.CategoryId = categoryId;

            return await Helpers.DatabaseHelper.SavePhoto(photo, connectionString);

        }

        public static async Task<Guid> AddProductToDatabase(Product product, string connectionString, string productCategoryName = null)
        {
            if (productCategoryName == null)
            {
                return await Helpers.DatabaseHelper.SaveProduct(product, connectionString);
            }

            var categoryToBeInserted = new ProductCategory()
            {
                Name = productCategoryName
            };

            var categoryId = await Helpers.DatabaseHelper.SaveProductCategory(categoryToBeInserted, connectionString);

            product.CategoryId = categoryId;

            return await Helpers.DatabaseHelper.SaveProduct(product, connectionString);

        }
    }
}
