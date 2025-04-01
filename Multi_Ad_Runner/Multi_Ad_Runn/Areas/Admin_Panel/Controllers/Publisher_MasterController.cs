using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class Publisher_MasterController : Controller
    {
        // GET: Admin_Panel/Publisher_Master
        Publisher_MasterDLA pmd = new Publisher_MasterDLA();
        public ActionResult Index()
        {
            return View();
        }

        private static List<SelectListItem> BindCategory()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT * FROM Category_Master";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["C_Name"].ToString(),
                                Value = sdr["C_Id"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }

        public ActionResult AddPublisher()
        {
            Publisher_Master category = new Publisher_Master();
            category.Category_Master = BindCategory();
            return View(category);
        }
        [HttpPost]
        public ActionResult AddPublisher(Publisher_Master pm)
        {
            try
            {
                pm.Category_Master=BindCategory();
                var selectedItem = pm.Category_Master.Find(p => p.Value == pm.C_Id.ToString());
                if (pmd.InsertPublisher(pm) || selectedItem !=null)
                {
                    selectedItem.Selected = true;
                    ViewBag.Message = "Record Insert Successfully";
                    ModelState.Clear();
                   
                }
                Publisher_Master category = new Publisher_Master();
                category.Category_Master = BindCategory();
                return View(category);
                

            }
            catch(Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult ViewAllPublisher()
        {
            ModelState.Clear();
            return View(pmd.GetAllPublisher());
        }

        public ActionResult EditPublisher(int puid)
        {
            Publisher_Master publisher = new Publisher_Master();
            if (publisher != null)
            {
                return View(pmd.GetSinglePublisher(puid));

            }
            else
            {
                return RedirectToAction("ViewAllPublisher");
            }

        }
        [HttpPost]
        public ActionResult EditPublisher(int puid, Publisher_Master pm)
        {
            try
            {

                // TODO: Add update logic here 
                if (pmd.EditPublisher(pm))
                {
                    ViewBag.Message = "Data Update";
                    ModelState.Clear();
                }
                return RedirectToAction("ViewAllPublisher");
            }

            catch

            {
                return View();
            }
        }

        public ActionResult DeletePublisher(int puid)
        {
            try
            {
                if (pmd.DeletePublisherDetail(puid))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ViewAllPublisher");
            }
            catch
            {
                return View();
            }

        }

    }
}