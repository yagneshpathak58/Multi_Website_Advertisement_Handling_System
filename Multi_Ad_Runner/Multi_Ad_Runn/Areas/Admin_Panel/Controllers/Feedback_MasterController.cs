using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class Feedback_MasterController : Controller
    {
        User_MasterDLA umd = new User_MasterDLA();
        // GET: Admin_Panel/Feedback_Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewAllFeedback()
        {
            ModelState.Clear();
            return View(umd.GetAllFeedback());
        }
    }
}