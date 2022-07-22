using Sipsis.Admin.Attribute;
using Sipsis.Admin.Models;
using Sipsis.DAL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sipsis.Admin.Controllers
{
    [Auth]
    public class CustomerController : BaseController
    {
        // GET: Customer
        public ActionResult Index()
        {

            return View(service.CustomerService.GetAll());
        }
        
        public ActionResult Insert()
        {

            return View(service.MarketService.GetAll());
        }

        [HttpPost]
        public ActionResult Insert(CustomerVM gelen)
        {
            Customer customer = new Customer()
            {
                CustomerName = gelen.CustomerName,
                CustomerPhone = gelen.CustomerPhone,
                CustomerAdress = gelen.CustomerAdress,
                MarketID = gelen.MarketID,
                UserID = ((SessionContext)Session["SessionContext"]).ID,

            };
            service.CustomerService.Insert(customer);
            return Redirect("/Customer/Index");
        }






        
        [HttpPost]
        public ActionResult CustomerSearch(string Phone)
        {
            var result = service.CustomerService.PhoneSearch(Phone);
            if (result.ID !=0)
            {
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false,JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Update(int? ID)
        {
            if (ID !=null)
            {
                var bulunan = service.CustomerService.Find((int)ID);
                if (bulunan !=null)
                {
                    ViewBag.market = service.MarketService.GetAll();
                    return View(bulunan);
                }
                else
                {
                    return Redirect("/Customer/Index");
                }
            }
            else
            {
                return Redirect("/Customer/Index");
            }

        }

        [HttpPost]
        public ActionResult Update(CustomerVM vm)
        {
            if (ModelState.IsValid )
            {
                Customer cust = new Customer()
                {
                    ID = vm.ID,
                    MarketID = vm.MarketID,
                    CustomerName = vm.CustomerName,
                    CustomerAdress = vm.CustomerAdress,
                    CustomerPhone = vm.CustomerPhone,
                    UserID = ((SessionContext)Session["SessionContext"]).ID,

                };
                service.CustomerService.Update(cust);
                return Redirect("/Customer/Index");
            }
            else
            {
                return Redirect("/Customer/Index");
            }
        }
    }
}