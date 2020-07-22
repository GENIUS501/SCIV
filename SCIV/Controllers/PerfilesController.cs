using SCIV.Filters;
using SCIV.Models;
using SCIV.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Windows.Controls;

namespace SCIV.Controllers
{
    public class PerfilesController : Controller
    {
       // public void RemoveRange(int index, int count);
        // GET: Perfiles
        //Autorizar acceso al modulo
        // [AuthorizeUser(idmodulo: 2)]
        public ActionResult Index()
        {
            try
            {
                using (SCIVEntities db = new SCIVEntities())
                {
                    //Ent_Usuario = (Tab_Usuarios)HttpContext.Session["User"];
                    List<Tab_Perfiles> lista = db.Tab_Perfiles.ToList();
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
        //[AuthorizeUserPermises(accion: "A", idmodulo: 2)]
        public ActionResult Create(FormCollection frm, Tab_Perfiles per)
        {
            try
            {
                //Comprueba que los campos esten llenos
                if (!ModelState.IsValid)
                {
                    return View();
                }
                else
                {
                    using (var db = new SCIVEntities())
                    {
                        db.Tab_Perfiles.Add(per);
                        db.SaveChanges();
                    }
                    //FormCollection frm = new FormCollection();
                    Grabar(per, frm);
                    //Enviar datos a la alerta
                    TempData["msg"] = "<script>alert('Perfil Agregado exitosamente!!!');</script>";
                    //Volver al index del modulo
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Error al agregar el perfil!!!');</script>";
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }
        #endregion

        #region Metodo para guardar los permisos
        private void Grabar(Tab_Perfiles per, FormCollection frm)
        {
            try
            {
                #region Modulo Usuario 1
                if (frm["radusu"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 1;
                        //Agregar
                        if (frm["usuagregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["UsuActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["UsuEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["UsuConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Modulo Perfiles 2
                if (frm["radper"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 2;
                        //Agregar
                        if (frm["perAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["perActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["perEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["perConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Modulo Empresas 3
                if (frm["rademp"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 3;
                        //Agregar
                        if (frm["empAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["empActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["empEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["empConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Modulo Productos 4
                if (frm["radprod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 4;
                        //Agregar
                        if (frm["prodAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["prodActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["prodEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["prodConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Ingreso_productos 5
                if (frm["radingprod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 5;
                        //Agregar
                        if (frm["ingprodAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["ingprodActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["ingprodEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["ingprodConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Modulo lista_ventas 6
                if (frm["lisvenrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 6;
                        //Agregar
                        if (frm["lisvenAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["lisvenActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["lisvenEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["lisvenConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Modulo venta_detalle 7
                if (frm["vendrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 7;
                        //Agregar
                        if (frm["vendAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["vendActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["vendEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["vendConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region Modulo unir listas 8
                if (frm["ulrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 8;
                        //Agregar
                        if (frm["ulAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["ulActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["ulEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["ulConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region reporte_listas_ventas 9
                if (frm["replvrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 9;
                        //Agregar
                        if (frm["replvAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["replvActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["replvEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["replvConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region reporte_factura_venta 10
                if (frm["repfvrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 10;
                        //Agregar
                        if (frm["repfvAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["repfvActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["repfvEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["repfvConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region reporte_empresa 11
                if (frm["repemprod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 11;
                        //Agregar
                        if (frm["repempAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["repempActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["repempEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["repempConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region bitacora_ingreso_salida 12
                if (frm["bitsesrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 12;
                        //Agregar
                        if (frm["bitsesrodAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["bitsesrodActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["bitsesrodEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["bitsesrodConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

                #region bitacora_movimiento 13
                if (frm["bitmovrod"] == null)
                {

                }
                else
                {

                    using (var db = new SCIVEntities())
                    {
                        Tab_Permisos perm = new Tab_Permisos();
                        perm.Id_Perfil = per.Id_Perfil;
                        perm.Modulo = 13;
                        //Agregar
                        if (frm["bitmovAgregar"] != null)
                        {
                            perm.Agregar = "S";
                        }
                        else
                        {
                            perm.Agregar = "N";
                        }
                        //Actualizar
                        if (frm["bitmovActualizar"] != null)
                        {
                            perm.Modificar = "S";
                        }
                        else
                        {
                            perm.Modificar = "N";
                        }
                        //Eliminar
                        if (frm["bitmovEliminar"] != null)
                        {
                            perm.Eliminar = "S";
                        }
                        else
                        {
                            perm.Eliminar = "N";
                        }
                        //Consultar
                        if (frm["bitmovConsult"] != null)
                        {
                            perm.Consultar = "S";
                        }
                        else
                        {
                            perm.Consultar = "N";
                        }

                        //Grabar
                        db.Tab_Permisos.Add(perm);
                        db.SaveChanges();
                    }
                }
                #endregion

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region llenar
        private void llenar(int ida)
        {
            using (var db = new SCIVEntities())
            {
                List<Tab_Permisos> lista = db.Tab_Permisos.Where(a => a.Id_Perfil == ida).ToList();
                foreach (var list in lista)
                {
                    if (list.Modulo == 1)
                    {
                        ViewBag.Mod_Per = "true";
                        #region Permisos de acceso
                        if (list.Agregar == "S")
                        {
                            ViewBag.Agregar_Per = "true";
                        }
                        if (list.Modificar == "S")
                        {
                            ViewBag.Modificar_Per = "true";
                        }
                        if (list.Consultar == "S")
                        {
                            ViewBag.Consultar_Per = "true";
                        }
                        if (list.Eliminar == "S")
                        {
                            ViewBag.Eliminar_Per = "true";
                        }
                        #endregion
                    }
                    if (list.Modulo == 2)
                    {
                        ViewBag.Mod_Usu = "true";
                        #region Permisos de acceso
                        if (list.Agregar == "S")
                        {
                            ViewBag.Agregar_usu = "true";
                        }
                        if (list.Modificar == "S")
                        {
                            ViewBag.Modificar_usu = "true";
                        }
                        if (list.Consultar == "S")
                        {
                            ViewBag.Consultar_usu = "true";
                        }
                        if (list.Eliminar == "S")
                        {
                            ViewBag.Eliminar_usu = "true";
                        }
                        #endregion
                    }
                    if (list.Modulo == 3)
                    {
                        ViewBag.Mod_Emp = "true";
                        #region Permisos de acceso
                        if (list.Agregar == "S")
                        {
                            ViewBag.Agregar_Emp = "true";
                        }
                        if (list.Modificar == "S")
                        {
                            ViewBag.Modificar_Emp = "true";
                        }
                        if (list.Consultar == "S")
                        {
                            ViewBag.Consultar_Emp = "true";
                        }
                        if (list.Eliminar == "S")
                        {
                            ViewBag.Eliminar_Emp = "true";
                        }
                        #endregion
                    }

                    if (list.Modulo == 4)
                    {
                        ViewBag.Mod_Prod = "true";
                        #region Permisos de acceso
                        if (list.Agregar == "S")
                        {
                            ViewBag.Agregar_Prod = "true";
                        }
                        if (list.Modificar == "S")
                        {
                            ViewBag.Modificar_Prod = "true";
                        }
                        if (list.Consultar == "S")
                        {
                            ViewBag.Consultar_Prod = "true";
                        }
                        if (list.Eliminar == "S")
                        {
                            ViewBag.Eliminar_Prod = "true";
                        }
                        #endregion
                    }

                    if (list.Modulo == 5)
                    {
                        ViewBag.Mod_ingprod = "true";
                    }

                    if (list.Modulo == 6)
                    {
                        ViewBag.Mod_lisven = "true";
                        #region Permisos de acceso
                        if (list.Agregar == "S")
                        {
                            ViewBag.Agregar_lisven = "true";
                        }
                        if (list.Modificar == "S")
                        {
                            ViewBag.Modificar_lisven = "true";
                        }
                        if (list.Consultar == "S")
                        {
                            ViewBag.Consultar_lisven = "true";
                        }
                        if (list.Eliminar == "S")
                        {
                            ViewBag.Eliminar_lisven = "true";
                        }
                        #endregion
                    }

                    if (list.Modulo == 7)
                    {
                        ViewBag.Mod_vend = "true";
                    }

                    if (list.Modulo == 8)
                    {
                        ViewBag.Mod_ul = "true";
                    }

                    if (list.Modulo == 9)
                    {
                        ViewBag.Mod_replv = "true";
                    }

                    if (list.Modulo == 10)
                    {
                        ViewBag.Mod_repfv = "true";
                    }
                    if (list.Modulo == 11)
                    {
                        ViewBag.Mod_repemp = "true";
                    }

                    if (list.Modulo == 12)
                    {
                        ViewBag.Mod_bitses = "true";
                    }

                    if (list.Modulo == 13)
                    {
                        ViewBag.Mod_bitmov = "true";
                    }
                }
            }
        }
        #endregion

        #region llenar el edit

        public ActionResult Edit(string id)
        {
            try
            {

                //Abre y cierra la conexion a bd
                using (var db = new SCIVEntities())
                {
                    //Declara y llena el objeto Usu
                    int ida = int.Parse(id);
                    Tab_Perfiles per = db.Tab_Perfiles.Where(a => a.Id_Perfil == ida).FirstOrDefault();
                    llenar(int.Parse(id));
                    //ViewBag.Lista_Permisos = lista;
                    //Retorna los datos a la vista
                    return View(per);
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

        #region Modificar
        //Le indica al metodo que reciba los datos por el metodo post
        [HttpPost]
        //Evita que se inicie de otro formulario
        [ValidateAntiForgeryToken]
        //Action result es el tipo de dato que retorna la funcion
        public ActionResult Edit(Tab_Perfiles a, FormCollection frm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (var db = new SCIVEntities())
                {
                    //Esto llena la entidad con los datos correspondientes a la entidad traida de la bd
                    Tab_Perfiles registro = db.Tab_Perfiles.Find(a.Id_Perfil);
                    //Asigna los valores traidos por la entidad traida de la vista a la entidad traida de la base de datos
                    //registro.Id_Perfil = a.Nombre;
                    registro.Nombre_Perfil = a.Nombre_Perfil;
                    db.Tab_Permisos.RemoveRange(db.Tab_Permisos.Where(c => c.Id_Perfil == a.Id_Perfil));
                    //Guarda los cambios en bd
                    db.SaveChanges();
                }
                //Guarda los permisos
                Grabar(a, frm);
                //Envia los datos a la alerta
                TempData["msg"] = "<script>alert('Perfil Editado exitosamente!!!');</script>";
                //retorna al index del modulo
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Error al editar el perfil!!!');</script>";
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }
        #endregion

        #region llenar details
        //Autorizar acceso a la accion
       // [AuthorizeUserPermises(accion: "C", idmodulo: 2)]
        public ActionResult Details(string id)
        {
            try
            {
                using (var db = new SCIVEntities())
                {
                    int ida = int.Parse(id);
                    //Consulta los datos correspondientes al id proveniente de la vista
                    Tab_Perfiles registro = db.Tab_Perfiles.Where(a => a.Id_Perfil == ida).FirstOrDefault();
                    llenar(int.Parse(id));
                    //Tab_Usuarios usua = db.Tab_Usuarios.Find(id);
                    //Los devuelve a la vista
                    return View(registro);
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

        #region Borrar
        //Autorizar acceso a la accion
      //  [AuthorizeUserPermises(accion: "E", idmodulo: 2)]
        public ActionResult Delete(string id)
        {
            try
            {
                using (var db = new SCIVEntities())
                {
                    //Consulta los datos correspondientes al id proveniente de la vista
                    int ida = int.Parse(id);
                    Tab_Perfiles registro = db.Tab_Perfiles.Where(a => a.Id_Perfil == ida).FirstOrDefault();
                    //Remueve del arreglo de entidades la entidad identificada enviada por la vista
                    db.Tab_Permisos.RemoveRange(db.Tab_Permisos.Where(c => c.Id_Perfil == ida));
                    db.Tab_Perfiles.Remove(registro);                    
                    //Guarda los cambios en la base de datos
                    db.SaveChanges();
                    TempData["msg"] = "<script>alert('Perfil Eliminado exitosamente!!!');</script>";
                    return RedirectToAction("index");
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = "<script>alert('Error al eliminar el perfil!!!');</script>";
                ModelState.AddModelError("Error", ex.Message);
                return View();
            }
        }
        #endregion

    }
}