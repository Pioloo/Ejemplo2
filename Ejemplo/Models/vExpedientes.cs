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
    
    public partial class vExpedientes
    {
        public int id_Expediente { get; set; }
        public short Anio { get; set; }
        public string numero_Expediente { get; set; }
        public string Acta { get; set; }
        public string Averiguacion_Previa { get; set; }
        public Nullable<System.DateTime> fecha_Entrada { get; set; }
        public Nullable<System.DateTime> fecha_Consignacion { get; set; }
        public string NombreCompleto { get; set; }
        public string Estado_Comparescencia { get; set; }
        public string Estado_ProcesoAP { get; set; }
        public string Estado_Proceso { get; set; }
        public int id_DefPubJuzgado { get; set; }
        public int id_DefPubMinisterial { get; set; }
        public Nullable<byte> Id_Estatus { get; set; }
        public short Id_ClasificacionJuzgado { get; set; }
        public string Juzgado { get; set; }
        public string SituacionJuridica { get; set; }
        public Nullable<int> Id_Persona { get; set; }
    }
}