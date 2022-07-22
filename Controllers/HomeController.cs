using Sipsis.Admin.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sipsis.Admin.Controllers
{
    [Auth] //home controlller ıcındekı action resultlar auth controllerın ıcınden gecerrek calısacak.
    public class HomeController : BaseController
    {
        // home ındexe gideken ılk auth kontrol yapacak vr sessıon olup olmamasına gore anasayfaya yonlendırecek.
        
        public ActionResult Index()
        {
            
            return View();
        }
    }
}