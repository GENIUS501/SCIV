using SCIV.Filters;
using SCIV.Models;
using SCIV.Models.ViewModels;
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

        #region Agregar
        //Autorizar acceso a la accion
        //[AuthorizeUserPermises(accion: "A", idmodulo: 1)]
        public ActionResult Create(Tab_Usuarios a)
        {
            try
            {
                #region Llenar drop down
                //Declar la lista como objeto
                List<PerfilesViewModel> lista;
                //llena la lista que a su vez es una entidad
                using (var db = new SCIVEntities())
                {
                    //consulta
                    lista =
                        (from d in db.Tab_Perfiles
                         select new PerfilesViewModel
                         {
                             id_perfil = d.Id_Perfil,
                             Nombre_Perfil = d.Nombre_Perfil
                         }).ToList();
                }
                //Asignar y convertir los valores a items
                List<SelectListItem> items = lista.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Nombre_Perfil,
                        Value = d.id_perfil.ToString(),
                        Selected = false
                    };
                }
                );
                //enviar items a la vista
                ViewBag.items = items;
                #endregion
                //Comprueba que los campos esten llenos
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    //Agregado
                    using (var db = new SCIVEntities())
                    {
                        //Encriptar contrasena
                        string passa = Helper.EncodePassword(string.Concat(a.NickName.ToString(), a.Contrasena.ToString()));
                        //Asignar contrasena a la entidad
                        a.Contrasena = passa;
                        //Agrega la entidad al arreglo
                        db.Tab_Usuarios.Add(a);
                        //Guarda los cambios realizados en el arreglo en la bd
                        db.SaveChanges();
                        //Enviar datos a la alerta
                        TempData["msg"] = "<script>alert('Usuario Agregado exitosamente!!!');</script>";
                        //volver al index del modulo
                        return RedirectToAction("index");
                    }
                }
            }
            //Captura la excepcion
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Error al agregar el usuario!!!');</script>";
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }
        #endregion

        #region llenar edit
        //Autorizar acceso a la accion
       // [AuthorizeUserPermises(accion: "M", idmodulo: 1)]
        public ActionResult Edit(string id)
        {
            try
            {
                #region Llenar drop down
                //Declar la lista como objeto
                List<PerfilesViewModel> lista;
                //Abre y cierra la conexion a bd
                using (var db = new SCIVEntities())
                {
                    //consulta LInq
                    lista =
                        (from d in db.Tab_Perfiles
                         select new PerfilesViewModel
                         {
                             id_perfil = d.Id_Perfil,
                             Nombre_Perfil = d.Nombre_Perfil
                         }).ToList();
                }
                //Asignar y convertir los valores a items
                List<SelectListItem> items = lista.ConvertAll(d =>
                {
                    return new SelectListItem()
                    {
                        Text = d.Nombre_Perfil,
                        Value = d.id_perfil.ToString(),
                        Selected = false
                    };
                }
                );
                //enviar items a la vista
                ViewBag.items = items;
                #endregion
                //Abre y cierra la conexion a bd
                using (var db = new SCIVEntities())
                {
                    //Declara y llena el objeto Usu
                    Tab_Usuarios usu = db.Tab_Usuarios.Where(a => a.NickName == id).FirstOrDefault();
                    //Retorna los datos a la vista
                    return View(usu);
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