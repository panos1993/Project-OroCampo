using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OroCampo.WebSite.Controllers
{
    using System.Configuration;
    using System.Threading.Tasks;

    using OroCampo.WebSite.Models;

    public class LayoutController : Controller
    {
        // GET: Layout
        public ActionResult GetProducts()
        {
            return View();
        }

        public async Task<ActionResult> GetServices()
        {
            var services = await DatabaseHandler.Helpers.DatabaseHelper.GetServices(
                ConfigurationManager.AppSettings["ConnectionString"],
                false);

            return this.View(new LayoutServicesModel() { Services = services });
        }
    }
}