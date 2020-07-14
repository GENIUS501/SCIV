using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class VentaDetalleController : Controller
    {
        // GET: VentaDetalle
        public ActionResult Index()
        {
            return RedirectToAction("Create");
           // return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}