using Multi_Ad_Runn.Models;
using Multi_Ad_Runn.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Controllers
{
    public class PublisherMasterController : Controller
    {
        Publisher_MasterDLA pmd = new Publisher_MasterDLA();
        // GET: PublisherMaster

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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RequestPublisher()
        {
            Publisher_Master category = new Publisher_Master();
            category.Category_Master = BindCategory();
            return View(category);
        }
        [HttpPost]
        public ActionResult RequestPublisher(Publisher_Master pm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    pm.Category_Master = BindCategory();
                    var selectedItem = pm.Category_Master.Find(p => p.Value == pm.C_Id.ToString());
                    if (pmd.PublisherRequest(pm) || selectedItem != null)
                    {
                        selectedItem.Selected = true;
                        ViewBag.Message = "Request SuccessFully Sent PleaseWait For The Admin Response";
                        ModelState.Clear();

                    }
                }
                else
                {

                }
                
                Publisher_Master category = new Publisher_Master();
                category.Category_Master = BindCategory();
                return View(category);


            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Change_Password cp)
        {
            try
            {
                if (Session["mwpuid"] != null)
                {
                    cp.Pu_Id = Convert.ToInt32(Session["mwpuid"].ToString());


                    if (pmd.ChekOldPass(cp.Pu_Password, cp.Pu_Id))
                    {

                        if (cp.New_Password == cp.Confirm_Password)
                        {
                            if (pmd.ChangePassword(cp))
                            {

                                ViewBag.MessageS = "Password Change Successfully";
                                ModelState.Clear();

                            }
                            else
                            {
                                ViewBag.Message = "Password Not Change Successfully";
                            }
                        }
                        else
                        {
                            ViewBag.Message = "New Password And Confirm Password Not Match";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Old Password  Not Match";
                    }




                    return View();


                }
                else
                {
                    return RedirectToAction("SignIn", "Comman");
                }

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult PublisherProfile()
        {
            Publisher_Master model = new Publisher_Master();
            if (Session["mwpuid"] != null)
            {
                model.Pu_Id = Convert.ToInt32(Session["mwpuid"]);
                model.Pu_Name = Convert.ToString(Session["mwpuname"]);
                model.Pu_Email = Convert.ToString(Session["mwpuemail"]);

                Publisher_Master pm = new Publisher_Master();
                pm = pmd.GetPublisherData(model.Pu_Id);
                model.Pu_Contact = pm.Pu_Contact;
                model.Pu_WebSite = pm.Pu_WebSite;
                return View(model);
            }
            else
            {
                return RedirectToAction("SignIn", "Comman");
            }

        }

        [HttpPost]
        public ActionResult PublisherProfile(Publisher_Master pm)
        {
            try
            {

                // TODO: Add update logic here 
                if (pmd.EditPublisherProfile(pm))
                {
                    ViewBag.Message = "Data Update";
                    ModelState.Clear();
                }
                return RedirectToAction("PublisherProfile", "PublisherMaster");
            }

            catch

            {
                return View();
            }
        }

    }
}