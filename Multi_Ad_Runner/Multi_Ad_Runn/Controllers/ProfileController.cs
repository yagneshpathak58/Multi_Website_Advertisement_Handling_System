using Multi_Ad_Runn.Repository;
using Multi_Ad_Runn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Controllers
{
    public class ProfileController : Controller
    {
        User_MasterDLA umd = new User_MasterDLA();
        Order_MasterDLA omd = new Order_MasterDLA();
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            Change_Password model = new Change_Password();
            if (Session["mwpuid"] != null)
            {
                model.U_Id = Convert.ToInt32(Session["mwpuid"]);
                model.U_Name = Convert.ToString(Session["mwpuname"]);
               

                User_Master um = new User_Master();
                um = umd.GetUserData(model.U_Id);
                return View(model);
            }
            else
            {
                return RedirectToAction("SignIn", "Comman");
            }
        }
        [HttpPost]
        public ActionResult ChangePassword(Change_Password cp)
        {
            try
            {
                if (Session["mwpuid"] != null)
                {
                    cp.U_Id = Convert.ToInt32(Session["mwpuid"].ToString());
                    

                    if (umd.ChekOldPass(cp.U_Password,cp.U_Id))
                    {
                        
                        if(cp.New_Password == cp.Confirm_Password)
                        {
                            if (umd.ChangePassword(cp))
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

        public ActionResult UserProfile()
        {
            User_Master model = new User_Master();
            if (Session["mwpuid"] != null)
            {
                model.U_Id = Convert.ToInt32(Session["mwpuid"]);
                model.U_Name = Convert.ToString(Session["mwpuname"]);
                model.U_Email = Convert.ToString(Session["mwpuemail"]);

                User_Master um = new User_Master();
                um = umd.GetUserData(model.U_Id);
                model.U_Contact = um.U_Contact;
                return View(model);
            }
            else
            {
                return RedirectToAction("SignIn", "Comman");
            }

        }
        [HttpPost]
        public ActionResult UserProfile(User_Master um )
        {
            try
            {
                
                // TODO: Add update logic here 
                if (umd.EditUserProfile(um))
                {
                    ViewBag.Message = "Profile Update Successful";
                    ModelState.Clear();
                }
                return RedirectToAction("UserProfile", "Profile");
            }

            catch

            {
                return View();
            }
        }

        public ActionResult ViewOrderHistory(int? U_Id)
        {
           
            if (Session["mwpuid"] != null)
            {
                U_Id = Convert.ToInt32(Session["mwpuid"]);



                //model.Or_Id = um.Or_Id;
                //model.B_Num = um.B_Num;
                //model.U_Id = um.U_Id;
                //model.Ad_Price = um.Ad_Price;
                //model.Or_Status = um.Or_Status;
                //model.Or_Date = um.Or_Date;
                //model.Bi_Id = um.Bi_Id;
                //model.Bi_Location = um.Bi_Location;
                //model.Bi_Payment_Mode = um.Bi_Payment_Mode;
                //model.Bi_Payment_Id = um.Bi_Payment_Id;
                //model.Bi_SubAmmount = um.Bi_SubAmmount;
                //model.Bi_CGst = um.Bi_CGst;
                //model.Bi_SGST = um.Bi_SGST;
                //model.Bi_IGST = um.Bi_IGST;
                //model.Bi_Total_Price = um.Bi_Total_Price;
                //model.Bi_Status = um.Bi_Status;
                //model.Bi_Date = um.Bi_Date;
                return View(omd.GetOrder(U_Id));
            }
            else
            {
                return RedirectToAction("SignIn", "Comman");
            }

        }

        public ActionResult OrderDetail(int Bnum , int cid)
        {
            PaymentDetails pd = new PaymentDetails();
            if (pd != null)
            {
              
                return View(omd.GetOrderBillDetail(Bnum , cid));

            }
            else
            {
                return RedirectToAction("ViewAllUser");
            }

        }
    }
}