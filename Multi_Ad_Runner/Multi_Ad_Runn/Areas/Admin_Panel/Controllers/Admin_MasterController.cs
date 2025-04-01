using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class Admin_MasterController : Controller
    {
        Admin_MasterDLA amd = new Admin_MasterDLA();
        // GET: Admin_Panel/Admin_Master
        public ActionResult Index()
        {
           
                if (Session["mwaid"] != null)
                {
                    return RedirectToAction("Dashboard", "Admin_Master");

                }
                else
                {
                return View();
                }

            
            
            
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Admin_Master sm)
        {
            try
            {
                Admin_Master am=amd.AdminLogin(sm);
                if (am!=null)
                {

                    FormsAuthentication.SetAuthCookie(sm.A_U_Name, true);
                    Session["mwaid"] = sm.A_Id.ToString();
                    Session["mwauname"] = sm.A_U_Name.ToString();
                    Session["mwaname"] = sm.A_Name.ToString();
                    Session["mwaemail"]=sm.A_Email.ToString();
                    ModelState.Clear();
                    return RedirectToAction("Dashboard", "Admin_Master");
                }
                
                else
                {
                    //return RedirectToAction("Index", "Admin_Master");
                    ViewData["Message"] = "Plase Check Username Or Password";
                }

            }
            catch
            {
                ViewData["Message"] = "Plase Check User Name Or Password";
                //return RedirectToAction("Login", "Home");
            }
            return View();
        }
        public ActionResult Dashboard(string mwaid)
        {
            if (Session["mwaid"]==null)
            {
                return RedirectToAction("Index", "Admin_Master");
            }
            else
            {
                
                ViewBag.val= amd.CountUser();
                ViewBag.valp = amd.CountPublisher();
                ViewBag.valo= amd.CountAdRequest();
                ViewBag.valf= amd.CountFeedback();

                return View();
            }

            
        }
        
        public ActionResult Logout()
        {
            
            Session.Abandon();
            Session["mwaid"] = null;
            Session["mwauname"] = null;
            Session["mwaname"] = null;
            Session["mwaemail"] = null;

            return RedirectToAction("Index", "Admin_Master");

        }
        public ActionResult ChangePassword()
        {
            ViewBag.val = amd.CountUser();
            ViewBag.valp = amd.CountPublisher();
            ViewBag.valo = amd.CountAdRequest();
            ViewBag.valf = amd.CountFeedback();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(Change_Password cp)
        {
            try
            {
                if (Session["mwaid"] != null)
                {
                    cp.A_ID = Convert.ToInt32(Session["mwaid"].ToString());


                    if (amd.ChekOldPass(cp.A_Password, cp.A_ID))
                    {

                        if (cp.New_Password == cp.Confirm_Password)
                        {
                            if (amd.ChangePassword(cp))
                            {

                                ViewBag.Message1 = "Password Change Successfully";
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
                    return RedirectToAction("Index", "Admin_Master");
                }

            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}