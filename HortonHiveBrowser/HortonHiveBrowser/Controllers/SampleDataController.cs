using HortonHiveBrowser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HortonHiveBrowser.Controllers
{
    public class SampleDataController : Controller
    {
        //
        // GET: /SampleData/

        public ActionResult Index()
        {
            var dt = new HiveQueryData().GetDataFromHive();
            return View(dt);
        }

    }
}
