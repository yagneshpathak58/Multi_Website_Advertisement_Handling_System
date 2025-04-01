using Multi_Ad_Runn.Models;
using Multi_Ad_Runn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Controllers
{
    public class UserMasterController : Controller
    {
        User_MasterDLA umd = new User_MasterDLA();
        // GET: UserMaster
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(User_Master um)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    if (umd.RegistrationUser(um))
                    {
                        ViewBag.Message = "Registration Successfull";
                        ModelState.Clear();
                    }
                }
                else
                {

                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ContactUs(Feedback_Master fm)
        {
            try
            {
                if (umd.AddFeedback(fm))
                {
                    ViewBag.MessageS = "Thank You !! Your Message Is Recived";
                    ModelState.Clear();
                }
                return View();

            }
            catch
            {
                return View();
            }
        }
    }
}