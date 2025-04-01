using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class User_MasterController : Controller
    {
        User_MasterDLA umd = new User_MasterDLA();
        // GET: Admin_Panel/User_Master
        public ActionResult Index()
        {

            if (Session["mwaid"] != null)
            {
                return RedirectToAction("Dashboard", "Admin_Master");

            }
            else
            {
                return RedirectToAction("Index", "Admin_Master");
            }




        }

        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User_Master um)
        {
            try
            {
                if (umd.InsertUser(um))
                {
                    ViewBag.Message = "Record Insert Successfully";
                    ModelState.Clear();
                }
                return View();

            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewAllUser()
        {
            ModelState.Clear();
            return View(umd.GetAllUser());
        }
        public ActionResult EditUser(int uid)
        {
            User_Master user = new User_Master();
            if(user!=null)
            {
                return View(umd.GetSingleUser(uid));

            }
            else
            {
                return RedirectToAction("ViewAllUser");
            }
            
        }
        [HttpPost]
        public ActionResult EditUser(int uid,User_Master um)
        {
            try
            {

                // TODO: Add update logic here 
                if (umd.EditUser(um))
                {
                    ViewBag.Message = "Data Update";
                    ModelState.Clear();
                }
                return RedirectToAction("ViewAllUser");
            }

            catch

            {
                return View();
            }
        }
        public ActionResult DeleteUser(int uid)
        {
            try
            {
                if (umd.DeleteUserDetail(uid))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ViewAllUser");
            }
            catch
            {
                return View();
            }

        }

    }
}