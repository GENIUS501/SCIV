using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class ListaVentasController : Controller
    {
        // GET: ListaVentas
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

        #region Agregar
        public ActionResult Create(Tab_Lista_Ventas lis)
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Lista_Ventas_Detalles> lista = db.Tab_Lista_Ventas_Detalles.ToList();
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
        #endregion

        #region Editar
        public ActionResult Edit(string id)
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Lista_Ventas_Detalles> lista = db.Tab_Lista_Ventas_Detalles.ToList();
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
        #endregion

        #region Unir
        public ActionResult Unir(string id)
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
        #endregion

    }
}