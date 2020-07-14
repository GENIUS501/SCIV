using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class Reporte_Lista_VentasController : Controller
    {
        // GET: Reporte_Lista_Ventas
        public ActionResult Index()
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Lista_Ventas> lista = db.Tab_Lista_Ventas.ToList();
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