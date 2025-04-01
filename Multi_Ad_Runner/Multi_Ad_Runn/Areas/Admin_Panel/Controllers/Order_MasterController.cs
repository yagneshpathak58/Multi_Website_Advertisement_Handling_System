using Multi_Ad_Runn.Areas.Admin_Panel.Data;
using Multi_Ad_Runn.Areas.Admin_Panel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multi_Ad_Runn.Areas.Admin_Panel.Controllers
{
    public class Order_MasterController : Controller
    {
        Order_MasterDLA omd = new Order_MasterDLA();
        // GET: Admin_Panel/Order_Master
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAllOrder()
        {
            ModelState.Clear();
            return View(omd.GetAllOrder());
        }

        public ActionResult OrderDetail(int Bnum, int cid, int uid)
        {
            PaymentDetail pd = new PaymentDetail();
            if (pd != null)
            {

                return View(omd.GetOrderBillDetail(Bnum, cid,uid));

            }
            else
            {
                return RedirectToAction("ViewAllOrder");
            }

        }
    }
}