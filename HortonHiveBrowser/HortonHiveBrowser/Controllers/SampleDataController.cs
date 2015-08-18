using HortonHiveBrowser.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HortonHiveBrowser.Controllers
{
    public class SampleDataController : Controller
    {
        public class DataModel
        {
            public DataTable dt;
            public String HiveQl;
        }

        public ActionResult Index()
        {
            var dataModel = new DataModel { HiveQl = "SELECT * FROM sample_08 LIMIT 100;" };
            var dt = new HiveQueryDataService().GetDataFromHivet(dataModel.HiveQl);
            dataModel.dt = dt;
            return View(dataModel);
        }

        [HttpPost]
        public ActionResult returnAPage(string hiveQL)
        {
            var dataModel = new DataModel { HiveQl = hiveQL };
            var dt = new HiveQueryDataService().GetDataFromHive(dataModel.HiveQl);
            dataModel.dt = dt;
            return View("Index", dataModel);
        }

        [HttpPost]
        public ActionResult aa()
        {
            return View();
        }
    }
}
