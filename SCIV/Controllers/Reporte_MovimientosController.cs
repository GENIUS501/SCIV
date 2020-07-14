using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class Reporte_MovimientosController : Controller
    {
        // GET: Reporte_Movimientos
        public ActionResult Index()
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Bitacora_Movimientos> lista = db.Tab_Bitacora_Movimientos.ToList();
                    return View(lista);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Error al cargar los datos!!!');</script>";
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }
    }
}