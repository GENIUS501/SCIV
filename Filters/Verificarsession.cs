﻿using SCIV.Controllers;
using SCIV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCIV.Filters
{
    public class Verificarsession:ActionFilterAttribute
    {
        private Tab_Usuarios Ent_Usuario;
        //El metodo override es para recargar
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                //Esto indica que es un filtro
                base.OnActionExecuting(filterContext);
                //Captura la sesion enviada por el sistema
                Ent_Usuario = (Tab_Usuarios)HttpContext.Current.Session["User"];
                //Comprueba si la sesion existe si esta nula es que no existe
                if (Ent_Usuario == null)
                {
                    //Si es nula redirige a la pagina de login
                    if (filterContext.Controller is AccesoController == false)
                    {
                        filterContext.HttpContext.Response.Redirect("/Acceso/Login");
                    }



                }
                //Si esta llena no hace nada

            }
            catch (Exception)
            {
                //Si hay un error lo devuelve al login
                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

        }
    }
}