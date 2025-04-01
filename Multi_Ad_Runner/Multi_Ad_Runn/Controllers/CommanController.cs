using Multi_Ad_Runn.Models;
using Multi_Ad_Runn.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Multi_Ad_Runn.Controllers
{
    public class CommanController : Controller
    {
        Publisher_MasterDLA pmd = new Publisher_MasterDLA();
        User_MasterDLA umd = new User_MasterDLA();
        // GET: Comman
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignIn(Login l)
        {
            try
            {
                if (l.Log_Role == "Publisher")
                {
                    Publisher_Master pm = pmd.PublisherLogin(l.Log_Email,l.Log_Password);
                    if (pm != null)
                    {
                        FormsAuthentication.SetAuthCookie(pm.Pu_Email, true);
                        Session["mwpuid"] = pm.Pu_Id.ToString();

                        Session["mwpuname"] = pm.Pu_Name.ToString();
                        Session["mwpuemail"] = pm.Pu_Email.ToString();
                        Session["mwtype"] = "Publisher";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Comman");
                    }
                    else
                    {

                        ViewBag.Message = "Login Failed !!!  And Plase Check User Name Or Password";
                    }


                }
                else if (l.Log_Role == "User")
                {
                    User_Master um = umd.UserLogin(l.Log_Email, l.Log_Password);
                    if (um != null)
                    {
                        FormsAuthentication.SetAuthCookie(um.U_Email, true);
                        Session["mwpuid"] = um.U_Id.ToString();

                        Session["mwpuname"] = um.U_Name.ToString();
                        Session["mwpuemail"] = um.U_Email.ToString();
                        Session["mwtype"] = "User";
                        ModelState.Clear();
                        return RedirectToAction("Index", "Comman");

                    }
                    else
                    {

                        ViewBag.Message = "Login Failed !!!  And Plase Check User Name Or Password";
                    }

                }
                
                return View();
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult Help()
        {
            return View();
        }
        public ActionResult Logout()
        {

            Session.Abandon();
            Session["mwpuid"] = null;
            Session["mwpuname"] = null;
            Session["mwpuemail"] = null;
            Session["mwtype"] = null;

            return RedirectToAction("SignIn", "Comman");

        }
    }
}