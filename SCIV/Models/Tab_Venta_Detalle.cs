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
    
    public partial class Tab_Venta_Detalle
    {
        public int Numero_Venta { get; set; }
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
        public int porcentaje_ganancia { get; set; }
        public double precio_costo { get; set; }
        public string Nota_Adicional { get; set; }
        public string NickName_Creador { get; set; }
    
        public virtual Tab_Productos Tab_Productos { get; set; }
        public virtual Tab_Usuarios Tab_Usuarios { get; set; }
    }
}
