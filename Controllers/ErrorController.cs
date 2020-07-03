using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        //Operacion no autorizada
        public ActionResult UnauthorizedOperation(String msjeErrorExcepcion)
        {
            //Rotulo a mostrar
            // ViewBag.Error = "No tiene acceso";
            //Excepcion devuelta por authorizeuser
            //  ViewBag.msjeErrorExcepcion = msjeErrorExcepcion
            //Codigo actualizado esteticamente
            TempData["msg"] = "<script>alert('Error no tienes acceso!!!');</script>";
            //Vuelve a la vista
            return RedirectToAction("Index", "Home");
            //return View();
        }
    }
}