using System;
using System.Data;
using System.Web.Mvc;
using HortonHiveBrowser.Helpers;
using HortonHiveBrowser.Models;

namespace HortonHiveBrowser.Controllers
{
    public class SampleDataController : Controller
    {
        public ActionResult Index()
        {
            var dataModel = new DataModel {HiveQl = "SELECT * FROM sample_08 LIMIT 100;"};
            DataTable dt = new HiveQueryDataService().GetDataFromHivet(dataModel.HiveQl);
            dataModel.Dt = dt;
            return View(dataModel);
        }

        [HttpPost]
        public ActionResult ReturnAPage(string hiveQl)
        {
            var dataModel = new DataModel {HiveQl = hiveQl};
            DataTable dt = new HiveQueryDataService().GetDataFromHive(dataModel.HiveQl);
            dataModel.Dt = dt;
            return View("Index", dataModel);
        }

        public ActionResult ReturnAjson(string hiveQl)
        {
            var dataModel = new DataModel {HiveQl = hiveQl};
            DataTable dt = new HiveQueryDataService().GetDataFromHive(dataModel.HiveQl);
            dataModel.Dt = dt;

            return new JsonNetResult(dataModel);
        }

        public class DataModel
        {
            public DataTable Dt;
            public String HiveQl;
        }

        public class SimpleClass
        {
            public string Prprty;
        }
    }
}