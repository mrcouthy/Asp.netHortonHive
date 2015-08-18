using HortonHiveBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HortonHiveBrowser.Controllers
{
    public class SampleDataController : Controller
    {
        //
        // GET: /SampleData/

        public ActionResult Index()
        {
            var dt = new HiveQueryDataService().GetDataFromHivet("SELECT * FROM sample_08 LIMIT 100;");
            return View(dt);
        }
      

        [HttpPost]
        public ActionResult returnAPage(string hiveQL)
        {
            var dt = new HiveQueryDataService().GetDataFromHive(hiveQL);
            return View("Index",   dt);
        }

        [HttpPost]
        public ActionResult aa()
        {
            return View();
        }

        //public JsonResult Test()
        //{
        //    var dt = new HiveQueryDataService().GetDataFromHive();
        //    var model = new ReportModel();
        //    model.ReportDate = "Test";
        //    model.Report = dt;
        //    return new Json(model, JsonRequestBehavior.AllowGet);
        //}

    }
}
