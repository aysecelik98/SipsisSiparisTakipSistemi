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
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginControl(LoginVM gelen)
        {
            if (ModelState.IsValid)
            {
                if (service.UserService.logincontrol(gelen.UserName,gelen.Password))
                {
                    User use = service.UserService.FindUserName(gelen.UserName);
                    SessionContext _sessionContext = new SessionContext()
                    {
                        ID = use.ID,
                        UserName = use.UserName,
                        ImageURL = use.ImageURL
                    };
                    Session["SessionContext"] = _sessionContext;
                    return Json(true, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Redirect("/Login/Index");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return Redirect("/Login");
        }
    }
}