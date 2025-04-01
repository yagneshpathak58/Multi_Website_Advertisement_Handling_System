using Multi_Ad_Runn.Models;
using Multi_Ad_Runn.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Controllers
{
    public class BillOrderController : Controller
    {
        PaymentDetailsDLA pdd = new PaymentDetailsDLA();
        // GET: BillOrder

        
        private static List<SelectListItem> BindLocaation()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem {Text ="Gujarat", Value= "1" });
            items.Add(new SelectListItem { Text = "Delhi", Value = "2" });
            items.Add(new SelectListItem { Text = "Maharashtra", Value = "3" });
            items.Add(new SelectListItem { Text = "Rajasthan", Value = "4" });

            return items;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentOrderBill()
        {

            PaymentDetails model = new PaymentDetails();
            model = (PaymentDetails)Session["armmodel"];
           
            if (Session["mwpuid"] != null)
            {
                model.Location = BindLocaation();
                //model.locations = new List<Location>();
                //model.locations.Add(new Location { LID=1,LName="Gujarat"});
                //model.locations.Add(new Location { LID = 2, LName = "Delhi" });
                //model.locations.Add(new Location { LID = 3, LName = "Rajasthan" });
                //model.locations.Add(new Location { LID = 4, LName = "Maharashtra" });
                //var Bi_Location = new List<string>()
                //{
                //"Gujarat", "Delhi", "Rajasthan", "Maharashtra"
                //};

                //ViewBag.Location = Bi_Location;
                model.Bi_Location = "Gujarat";
                var SelectedValue = model.Bi_Location;
                if (model != null)
                {
                    DateTime d1 = System.DateTime.Now;
                    DateTime d2;
                    double p1,p2;
                    double gst = 18;
                    double  cgst, sgst, igst,subammount,totalammount;
                    

                    p1 = Convert.ToDouble(model.Ad_Price);
                  
                    

                    if (model.A_R_Duration == "1")
                    {
                        d2 = d1.AddMonths(1);
                        p2 = 1 * p1;
                        model.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());
                        model.Bi_SubAmmount = Convert.ToString(p2.ToString());
                      
                    }
                    else if (model.A_R_Duration == "3")
                    {
                        d2 = d1.AddMonths(3);
                        p2 = 3 * p1;
                        model.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());
                        model.Bi_SubAmmount = Convert.ToString(p2.ToString());
                        cgst = 0;
                        sgst = 0;
                        igst = gst *p2;
                        model.Bi_CGst = Convert.ToString(cgst.ToString());
                        model.Bi_SGST = Convert.ToString(sgst.ToString());
                        model.Bi_IGST = Convert.ToString(igst.ToString());

                    }
                    else if (model.A_R_Duration == "6")
                    {
                        d2 = d1.AddMonths(6);
                        p2 = 6 * p1;
                        model.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());
                        model.Bi_SubAmmount = Convert.ToString(p2.ToString());
                    }
                    else if (model.A_R_Duration == "12")
                    {
                        d2 = d1.AddMonths(12);
                        p2 = 12 * p1;
                        model.A_R_Expire_Date = Convert.ToDateTime(d2.ToString());
                        model.Bi_SubAmmount = Convert.ToString(p2.ToString());
                    }
                    else
                    {

                        ViewBag["Message"] = "Ad Duration Are Not Select";

                    }
                    subammount=Convert.ToDouble(model.Bi_SubAmmount);

                    if (SelectedValue == "Gujarat")
                    {
                        cgst = gst * subammount / 100 * 2;
                        sgst = gst * subammount / 100 * 2;
                        igst = 0;
                        model.Bi_Location = "Gujarat";
                        model.Bi_CGst = Convert.ToString(cgst.ToString());
                        model.Bi_SGST = Convert.ToString(sgst.ToString());
                        model.Bi_IGST = Convert.ToString(igst.ToString());
                        totalammount = cgst + sgst + igst + subammount;
                        model.Bi_Total_Price = Convert.ToString(totalammount.ToString());
                    }
                    else if (SelectedValue != "Gujarat")
                    {
                        cgst = 0;
                        sgst = 0;
                        igst = gst * subammount / 100;
                        model.Bi_Location = Convert.ToString(SelectedValue.ToString());
                        model.Bi_CGst = Convert.ToString(cgst.ToString());
                        model.Bi_SGST = Convert.ToString(sgst.ToString());
                        model.Bi_IGST = Convert.ToString(igst.ToString());
                        totalammount = cgst + sgst + igst + subammount;
                        model.Bi_Total_Price = Convert.ToString(totalammount.ToString());
                    }
                    else
                    {
                        ViewBag["Message"] = "Please Select Location ";
                    }

                    model.U_Id = Convert.ToInt32(Session["mwpuid"]);
                    model.U_Name = Convert.ToString(Session["mwpuname"]);
                    model.U_Email = Convert.ToString(Session["mwpuemail"]);
                    

                   
                }
                PaymentDetails pdg=new PaymentDetails();
                pdg=pdd.GetData(model.C_Id, model.U_Id, model.Ad_Price);
                model.U_Contact = pdg.U_Contact;
                model.C_Name = pdg.C_Name;
                return View(model);
                 
            }
            else
            {
                return RedirectToAction("SignIn", "Comman");
            }

        }

        [HttpPost]

        public ActionResult PaymentOrderBill(PaymentDetails pd)
        {
            try
            {

                if (Session["mwpuid"] != null)
                {

                   
                   
                    
                    if (pd.Bi_Payment_Mode == "UPI")
                    {
                        pd.Bi_Payment_Mode = Convert.ToString(pd.Bi_Payment_Mode);
                    }
                    else
                    {
                        pd.Bi_Payment_Mode = "Credit/DebitCard";
                    }
                    Random random = new Random();
                    var r = random.Next();

                    if (pdd.CheckBnum(pd.B_Num))
                    {
                        Random random1 = new Random();
                        var r1 = random1.Next();
                        pd.B_Num = Convert.ToInt32(r1);
                    }
                    else
                    {
                        pd.B_Num = Convert.ToInt32(r);
                    }


                    if (pdd.AdRequest(pd) && pdd.AddBill(pd) && pdd.AddOrder(pd))
                    {
                        
                        ViewBag.Message = "Request SuccessFully Sent PleaseWait For The Admin Response";
                        ModelState.Clear();
                        return RedirectToAction("PaymentSuccess", "BillOrder");
                    }

                    PaymentDetails model = new PaymentDetails();
                    model.Location = BindLocaation();
                    return View(model);


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

        public ActionResult PaymentSuccess()
        {
            return View();
        }

        public ActionResult temoM(PaymentDetails pd)
        {
            

                return View();
        }
    }
}