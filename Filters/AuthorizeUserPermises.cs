using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Filters
{
    //No permite mulitples
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUserPermises : AuthorizeAttribute
    {
        //Declaracion de variables
        private Tab_Usuarios oUsuario;
        private SCIVEntities db = new SCIVEntities();
        private int numero_modulo;
        private string accion;
        //Captura el numero del modulo al que se desea acceder 
        public AuthorizeUserPermises(string accion, int idmodulo = 0)
        {
            this.numero_modulo = idmodulo;
            this.accion = accion;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            try
            {
                //Le asigna el valor de la sesion al objeto de tipo entidad usuario
                oUsuario = (Tab_Usuarios)HttpContext.Current.Session["User"];
                //Valida que la accion este permitida en el perfil.
                if (accion == "A")//Agregar
                {
                    //Llena la entidad permisos con los valores de la tabla permisos de base de datos si existen
                    var lstMisOperaciones = from m in db.Tab_Permisos
                                            where m.Id_Perfil == oUsuario.Id_Perfil && m.Modulo == numero_modulo && m.Agregar == "S"
                                            select m;
                    //Si es meno o igual a cero es que el permiso no existe y por lo tanto no puede acceder al modulo
                    if (lstMisOperaciones.ToList().Count() <= 0)
                    {
                        //Envia el error a pantalla
                        filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?msjeErrorExcepcion=error_de_acceso");
                    }
                }
                if (accion == "M")//Actializar o modificar
                {
                    //Llena la entidad permisos con los valores de la tabla permisos de base de datos si existen
                    var lstMisOperaciones = from m in db.Tab_Permisos
                                            where m.Id_Perfil == oUsuario.Id_Perfil && m.Modulo == numero_modulo && m.Modificar == "S"
                                            select m;
                    //Si es meno o igual a cero es que el permiso no existe y por lo tanto no puede acceder al modulo
                    if (lstMisOperaciones.ToList().Count() <= 0)
                    {
                        //Envia el error a pantalla
                        filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?msjeErrorExcepcion=error_de_acceso");
                    }
                }
                if (accion == "E")//Eliminar
                {
                    //Llena la entidad permisos con los valores de la tabla permisos de base de datos si existen
                    var lstMisOperaciones = from m in db.Tab_Permisos
                                            where m.Id_Perfil == oUsuario.Id_Perfil && m.Modulo == numero_modulo && m.Eliminar == "S"
                                            select m;
                    //Si es meno o igual a cero es que el permiso no existe y por lo tanto no puede acceder al modulo
                    if (lstMisOperaciones.ToList().Count() <= 0)
                    {
                        //Envia el error a pantalla
                        filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?msjeErrorExcepcion=error_de_acceso");
                    }
                }
                if (accion == "C")//Consultar
                {
                    //Llena la entidad permisos con los valores de la tabla permisos de base de datos si existen
                    var lstMisOperaciones = from m in db.Tab_Permisos
                                            where m.Id_Perfil == oUsuario.Id_Perfil && m.Modulo == numero_modulo && m.Consultar == "S"
                                            select m;
                    //Si es meno o igual a cero es que el permiso no existe y por lo tanto no puede acceder al modulo
                    if (lstMisOperaciones.ToList().Count() <= 0)
                    {
                        //Envia el error a pantalla
                        filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?msjeErrorExcepcion=error_de_acceso");
                    }
                }
            }
            catch (Exception ex)
            {
                //Envia el error a pantalla
                filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperationmsjeErrorExcepcion=" + ex.Message);
            }
        }
    }
}