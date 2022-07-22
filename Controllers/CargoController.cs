using Sipsis.Admin.Attribute;
using Sipsis.Admin.Models;
using Sipsis.DAL.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sipsis.Admin.Controllers
{
    [Auth]
    public class CargoController : BaseController
    {
        // GET: Cargo
        public ActionResult Index()
        {
            return View(service.CargoService.GetAll());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(CargoVM vm,HttpPostedFileBase resim)
        {
            //dosya yolu yaratmak için 
            if (resim != null)
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string resimAdi = vm.CargoName + uzanti;
                string dosyaYolu = Server.MapPath("/Assets/Img/" + resimAdi);
                resim.SaveAs(dosyaYolu);

                Cargo crg = new Cargo()
                {
                    CargoName = vm.CargoName,
                    UserID = ((SessionContext)Session["SessionContext"]).ID,
                    CargoImageURL = "/Assets/Img/" + resimAdi,

                };
                service.CargoService.Insert(crg);
                return Redirect("/Cargo/Index");
            }
            else
            {
                Cargo crg = new Cargo()
                {
                    CargoName = vm.CargoName,
                    UserID = ((SessionContext)Session["SessionContext"]).ID,
                    CargoImageURL = "/Assets/Img/null.png"

                };
                service.CargoService.Insert(crg);
                return Redirect("/Cargo/Index");
            }
        }


        public ActionResult Update(int? ID)
        {
            //veritabenında verileri görüntüleme işlemleri yapıldı bir takım get işlemi
            if (ID != null)
            {
                var bul = service.CargoService.Find((int)ID);

                return View(bul);
            }
            else
            {
                return Redirect("/Cargo/Index");
          
           }

        }
        [HttpPost]
        public ActionResult Update(CargoVM vm ,HttpPostedFileBase resim)
        {

            if (resim == null)
            {
                Cargo crg = new Cargo()
                {
                    CargoImageURL = "/Assets/Img/null.png",
                    CargoName = vm.CargoName,
                    ID = vm.ID,
                    UserID = ((SessionContext)Session["SessionContext"]).ID
                };
                service.CargoService.Update(crg);
                return Redirect("/Cargo/Index");

            }
            else
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string resimAdi = vm.CargoName + uzanti;
                string dosyaYolu = Server.MapPath("/Assets/Img/" + resimAdi);
                resim.SaveAs(dosyaYolu);


                Cargo crg = new Cargo()
                {
                    CargoName = vm.CargoName,
                    ID = vm.ID,
                    UserID = ((SessionContext)Session["SessionContext"]).ID,
                    CargoImageURL = "/Assets/Img" + resimAdi,

                };
                service.CargoService.Update(crg);
                return Redirect("/Cargo/Index");
            }

        }

    }
}