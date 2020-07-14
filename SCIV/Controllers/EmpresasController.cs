using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class EmpresasController : Controller
    {
        // GET: Empresas
        public ActionResult Index()
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Empresa> lista = db.Tab_Empresa.ToList();
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
            public ActionResult Create(Tab_Empresa emp)
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

        #region Details
        public ActionResult Details(string id)
        {
            return View();
        }
            #endregion

        }
}