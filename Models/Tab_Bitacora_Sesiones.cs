//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SCIV.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tab_Bitacora_Sesiones
    {
        public int Id_Sesion { get; set; }
        public System.DateTime Ingreso { get; set; }
        public Nullable<System.DateTime> Salida { get; set; }
        public string NickName { get; set; }
    
        public virtual Tab_Usuarios Tab_Usuarios { get; set; }
    }
}
