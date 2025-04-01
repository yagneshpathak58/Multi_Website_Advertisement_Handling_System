using Multi_Ad_Runn.Models;
using Multi_Ad_Runn.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Controllers
{
    public class AdRequestMasterController : Controller
    {
        Ad_Request_MasterDLA armd = new Ad_Request_MasterDLA();
        PaymentDetailsDLA pdd = new PaymentDetailsDLA();

        private static List<SelectListItem> BindCategory()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["MWAH_DB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = " SELECT * FROM Category_Master WHERE C_Status != 'Deleted'";
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
        // GET: AdRequestMaster
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdRequest()
        {
            Ad_Request_Master category = new Ad_Request_Master();
            category.Category_Master = BindCategory();
            return View(category);
        }
        [HttpPost]
        public ActionResult AdRequest(PaymentDetails pd )
        {
            try
            {
                
                if (Session["mwpuid"] != null)
                {
                    if(pd.C_Id!=null)
                    {
                        PaymentDetails pdd2 = pdd.GetPrice(pd.A_R_Page, pd.A_R_Position);
                        if (pdd2 != null)
                        {
                            pd.Ad_Price = Convert.ToString(pdd2.Ad_Price);
                        }


                        string filename = " ", filepath = "";

                        if (Request.Files.Count != 0)
                        {
                            var f = Request.Files[0];
                            Random random = new Random();
                            filename = Path.GetFileName(random.Next() + "_" + f.FileName);
                            filepath = Path.Combine(Server.MapPath("~/Ad_RequestImage/"), filename);
                            f.SaveAs(filepath);
                            pd.A_R_ImageName = filename;
                            pd.A_R_ImagePath = "../Ad_RequestImage/" + filename;




                        }
                        else
                        {
                            ViewBag.Message = "Please Select Image";
                        }

                        Session["armmodel"] = pd;
                        ModelState.Clear();
                        return RedirectToAction("PaymentOrderBill", "BillOrder");
                    }
                    else 
                    {
                        
                    }
                    
                    
                }
                Ad_Request_Master category = new Ad_Request_Master();
                category.Category_Master = BindCategory();
                return View(category);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
            //try
            //{
            //    if (Session["mwpuid"] != null)
            //    {
            //        DateTime d1 = System.DateTime.Now;
            //        DateTime d2;
            //        if(arm.A_R_Duration == "1")
            //        {
            //            d2 = d1.AddMonths(1);
            //            arm.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());

            //        }
            //        else if(arm.A_R_Duration == "3")
            //        {
            //            d2 = d1.AddMonths(3);
            //            arm.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());

            //        }
            //        else if (arm.A_R_Duration == "6")
            //        {
            //            d2 = d1.AddMonths(6);
            //            arm.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());

            //        }
            //        else if (arm.A_R_Duration == "12")
            //        {
            //            d2 = d1.AddMonths(12);
            //            arm.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());

            //        }
            //        else 
            //        {

            //            ViewBag["Message"] = "Ad Duration Are Not Select";

            //        }
            //        string filename = " ", filepath = "";
            //        arm.Category_Master = BindCategory();
            //        var selectedItem = arm.Category_Master.Find(p => p.Value == arm.C_Id.ToString());
            //        if (Request.Files.Count != 0  )
            //        {
            //            var f = Request.Files[0];
            //            Random random = new Random();
            //            filename = Path.GetFileName(random.Next() + "_" + f.FileName);
            //            filepath = Path.Combine(Server.MapPath("~/Ad_RequestImage/"), filename);
            //            f.SaveAs(filepath);
            //            arm.A_R_ImageName = filename;
            //            arm.A_R_ImagePath = "~/Ad_RequestImage/" + filename;
            //            arm.U_Id = Convert.ToInt32(Session["mwpuid"]);
                        


            //        }
            //        else
            //        {
            //            ViewBag.Message = "Please Select Image";
            //        }
            //        if (armd.AdRequest(arm) || selectedItem != null)
            //        {
            //            selectedItem.Selected = true;
            //            ViewBag.Message = "Request SuccessFully Sent PleaseWait For The Admin Response";
            //            ModelState.Clear();
            //            return RedirectToAction("PaymentOrderBill", "BillOrder");
            //        }
            //        Ad_Request_Master category = new Ad_Request_Master();
            //        category.Category_Master = BindCategory();
            //        return View(category);


            //    }
            //    else
            //    {
            //        return RedirectToAction("SignIn","Comman");
            //    }
                
            //}
            //catch (Exception ex)
            //{
            //    return View(ex);
            //}
           
        }

       
        
    }
}