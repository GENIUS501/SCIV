using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            try
            {
                //Abre y cierra la conexion a bd
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Llena la lista de usuarios
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Usuarios> lista = db.Tab_Usuarios.ToList();
                    //Devuelve la lista ala vista
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

        #region Traer el nombre del perfil
        public static string NombrePerfil(string id)
        {
            try
            {
                using (var db = new SCIVEntities())
                {
                    //Retorna el nombre del perfil correspondiente al id enviado al metodo
                    return db.Tab_Perfiles.Find(int.Parse(id)).Nombre_Perfil;
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion
    }
}