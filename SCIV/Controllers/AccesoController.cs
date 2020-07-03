using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //Recibe el usuario y la contrasena del sistema
        public ActionResult Login(string Usuario, string Pass)
        {
            try
            {
                using (Models.SCIVEntities db = new Models.SCIVEntities())
                {
                    //Encripta la contrasena para realizar la prueba
                    string passa = Helper.EncodePassword(string.Concat(Usuario.ToString(), Pass.ToString()));
                    //Se consulta la base de datos con la contrasena y el usuario dados por usuario 
                    var Ent_Unsuario = (from d in db.Tab_Usuarios
                                        where d.NickName == Usuario && d.Contrasena == passa
                                        select d).FirstOrDefault();
                    //Si la base no devolvio la entidad usuarios llena es por que el usuario o la clave esta mal
                    if (Ent_Unsuario == null)
                    {
                        //Expresa el error a la vista
                        //ViewBag.Error = "Usuario o Contrasena invalida!!!";
                        //Notifica que la clave esta incorrecta
                        TempData["msg"] = "<script>alert('Usuario o contrasena invalida!!!');</script>";
                        return View();
                    }
                    else
                    {
                        //Crea la sesion con la que el sistema validara
                        Session["User"] = Ent_Unsuario;
                        TempData["msg"] = "<script>alert('Bienvenido " + Ent_Unsuario.NickName + "');</script>";
                        //Redirige a la pagina principal del sistema
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}