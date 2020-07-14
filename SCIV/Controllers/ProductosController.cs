using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class ProductosController : Controller
    {
        // GET: Productos
        public ActionResult Index()
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Productos> lista = db.Tab_Productos.ToList();
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

        #region proceso
        public ActionResult Ingresar(Tab_Productos prod)
        {
            return View();
        }
        #endregion

        #region Agregar
        public ActionResult Create(Tab_Productos prod)
        {
            return View();
        }
        #endregion

        #region Editar
        public ActionResult Edit(string id)
        {
            return View();
        }
        #endregion

        #region Consultar
        public ActionResult Details(string id)
        {
            return View();
        }
        #endregion
    }
}