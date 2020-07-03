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
    public class AuthorizeUser : AuthorizeAttribute
    {
        //Declaracion de variables
        private Tab_Usuarios oUsuario;
        private SCIVEntities db= new SCIVEntities();
        private int numero_modulo;
        //Captura el numero del modulo al que se desea acceder 
        public AuthorizeUser(int idmodulo = 0)
        {
            this.numero_modulo = idmodulo;
        }
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                //Le asigna el valor de la sesion al objeto de tipo entidad usuario
                oUsuario = (Tab_Usuarios)HttpContext.Current.Session["User"];
                //Llena la entidad permisos con los valores de la tabla permisos de base de datos si existen
                var lstMisOperaciones = from m in db.Tab_Permisos
                                        where m.Id_Perfil == oUsuario.Id_Perfil && m.Modulo == numero_modulo
                                        select m;
                //Si es meno o igual a cero es que el permiso no existe y por lo tanto no puede acceder al modulo
                if (lstMisOperaciones.ToList().Count() <= 0)
                {
                    //Envia el error a pantalla
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation?msjeErrorExcepcion=error_de_acceso");
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