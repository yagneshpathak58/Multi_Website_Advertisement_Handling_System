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
    public class Ad_MasterController : Controller
    {
        Admin_MasterDLA admd = new Admin_MasterDLA();
        Ad_MasterDLA amd = new Ad_MasterDLA();
        // GET: Admin_Panel/Ad_Master
        public ActionResult Index()
        {
            return View();
        }

        //private static List<SelectListItem> BindPublisher()
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    string constr = ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        string query = " SELECT * FROM Publisher_Master WHERE Pu_Status != 'Deleted'";
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            using (SqlDataReader sdr = cmd.ExecuteReader())
        //            {
        //                while (sdr.Read())
        //                {
        //                    items.Add(new SelectListItem
        //                    {
        //                        Text = sdr["Pu_Name"].ToString(),
        //                        Value = sdr["Pu_Id"].ToString()
        //                    });
        //                }
        //            }
        //            con.Close();
        //        }
        //    }

        //    return items;
        //}

        public ActionResult Add_Ad()
        {
            ViewBag.val = admd.CountUser();
            ViewBag.valp = admd.CountPublisher();
            ViewBag.valo = admd.CountAdRequest();
            ViewBag.valf = admd.CountFeedback();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Ad(Ad_Master am)
        {
            try
            {
               
                if (amd.InsertAd(am))
                {
                    
                    ViewBag.Message = "Record Insert Successfully";
                    ModelState.Clear();

                }
               
                return View();


            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult ViewAllAd()
        {
            ViewBag.val = admd.CountUser();
            ViewBag.valp = admd.CountPublisher();
            ViewBag.valo = admd.CountAdRequest();
            ViewBag.valf = admd.CountFeedback();
            ModelState.Clear();
            return View(amd.GetAllAd());
        }

        public ActionResult EditAd(int adid)
        {
            Ad_Master ad = new Ad_Master();
            if (ad != null)
            {
                ViewBag.val = admd.CountUser();
                ViewBag.valp = admd.CountPublisher();
                ViewBag.valo = admd.CountAdRequest();
                ViewBag.valf = admd.CountFeedback();
                return View(amd.GetSingleAd(adid));

            }
            else
            {
                return RedirectToAction("ViewAllAd");
            }

        }
        [HttpPost]
        public ActionResult EditAd(int adid, Ad_Master am)
        {
            try
            {

                // TODO: Add update logic here 
                if (amd.EditAd(am))
                {
                    ViewBag.Message = "Data Update";
                    ModelState.Clear();
                }
                return RedirectToAction("ViewAllAd");
            }

            catch

            {
                return View();
            }
        }

        public ActionResult DeleteAd(int adid)
        {
            try
            {
                if (amd.DeleteAdDetail(adid))
                {
                    ViewBag.Message = "Data Deleted";
                }
                return RedirectToAction("ViewAllAd");
            }
            catch
            {
                return View();
            }

        }
    }
}