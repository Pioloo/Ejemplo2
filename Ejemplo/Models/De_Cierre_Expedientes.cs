//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ejemplo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class De_Cierre_Expedientes
    {
        public short Id_Anio { get; set; }
        public int Id_Expediente { get; set; }
        public byte Id_Tipo_Cierre { get; set; }
        public int Id_Acusado { get; set; }
        public Nullable<int> Id_Causa { get; set; }
        public Nullable<byte> Id_Sentencia { get; set; }
        public string Comentarios { get; set; }
        public string Comentario_Seguimiento { get; set; }
        public string Nombre_Archivo { get; set; }
        public string Nombre_Archivo_Original { get; set; }
        public Nullable<short> Usu_Act { get; set; }
        public Nullable<System.DateTime> Fecha_Act { get; set; }
    }
}
