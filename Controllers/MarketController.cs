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
    public class MarketController : BaseController
    {
      
        public ActionResult Index()
        {
            var liste = service.MarketService.GetAll();
            return View(liste);
        }
        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(MarketVM gelen)
        {
            
            Market market = new Market()
            {
                MarketName = gelen.MarketName,
                Comission = gelen.Comission,
                UserID =((SessionContext)Session["SessionContext"]).ID,

            };
            service.MarketService.Insert(market);
            return Redirect("/Market/Index");
        }
        public ActionResult Update(int? ID)
        {
            if (ID != null)
            {
                var bulunan = service.MarketService.Find((int)ID);
                if (bulunan!= null)
                {
                    return View(bulunan);

                }
                else
                {
                    return Redirect("/Market/Index");
                }
            }
            else
            {
                return Redirect("/Market/Index");
            }
        }

        [HttpPost]
        public ActionResult Update(MarketVM gelen)
        {
            if (ModelState.IsValid)
            {
                Market market = new Market()
                {
                    Comission = gelen.Comission,
                    MarketName = gelen.MarketName,
                    ID = gelen.ID,
                    UserID = ((SessionContext)Session["SessionContext"]).ID
                };

                service.MarketService.Update(market);
                return Redirect("/Market/Index");
            }
            else
            {
                return Redirect("/Market/Index");
            }
        }
    }
}