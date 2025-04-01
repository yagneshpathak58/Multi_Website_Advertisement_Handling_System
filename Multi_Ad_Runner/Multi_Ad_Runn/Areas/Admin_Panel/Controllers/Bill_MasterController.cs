using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class Bill_MasterController : Controller
    {
        Bill_MasterDLA bmd = new Bill_MasterDLA();
        // GET: Admin_Panel/Bill_Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllBill()
        {
            ModelState.Clear();
            return View(bmd.GetAllBill());
        }
    }
}