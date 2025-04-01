using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class Category_MasterController : Controller
    {
        Category_MasterDLA cmd = new Category_MasterDLA();

        public ActionResult Index(string mwaid)
        {



            if (Session["mwaid"] == null)
            {
                return RedirectToAction("Index", "Admin_Master");
            }
            else
            {
                ViewBag.mwaid = mwaid;
                return View();
            }

            
           




        }
        // GET: Admin_Panel/Category_Master
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category_Master cm)
        {
            try
            {
                if (cmd.InsertCatogery(cm))
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

        public ActionResult ViewAllCategory()
        {
            ModelState.Clear();
            return View(cmd.GetAllCategory());
        }
        public ActionResult EditCategory(int cid)
        {
            return View(cmd.GetAllCategory().Find(cm => cm.C_Id == cid));

        }
        // POST: Admin_Panel/Category_Master/5
        [HttpPost]
        public ActionResult EditCategory(int cid, Category_Master cm)
        {

            try
            {

                // TODO: Add update logic here 
                if (cmd.EditCategory(cm))
                {
                    ViewBag.Message = "Data Update";
                    ModelState.Clear();
                }
                return RedirectToAction("ViewAllCategory");
            }

            catch

            {
                return View();
            }
        }

        
        public ActionResult DeleteCategory(int cid)
        {
            try
            {
                if (cmd.DeleteCategory(cid)) 
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ViewAllCategory");
            }
            catch
            {
                return View() ;
            }

        }
    }
}