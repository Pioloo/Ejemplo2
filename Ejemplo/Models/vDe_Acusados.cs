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
    
    public partial class vDe_Acusados
    {
        public short Anio { get; set; }
        public int Id_Expediente { get; set; }
        public int Id_Persona { get; set; }
        public string curp { get; set; }
        public string nombre { get; set; }
        public string primer_Apellido { get; set; }
        public string segundo_Apellido { get; set; }
        public string NombreCompleto { get; set; }
        public Nullable<int> id_Domicilio { get; set; }
        public string Cedula_Profesional { get; set; }
        public string Telefono { get; set; }
        public string Id_AccionProcesal { get; set; }
        public string Etapa { get; set; }
        public string Accion { get; set; }
        public Nullable<int> Id_DPM_Responsable { get; set; }
        public Nullable<int> Id_DPJ_Responsable { get; set; }
        public Nullable<byte> Id_Estatus { get; set; }
        public Nullable<byte> Id_Tipo_Cierre { get; set; }
        public Nullable<short> Usu_Act { get; set; }
        public Nullable<System.DateTime> Fecha_Act { get; set; }
        public Nullable<byte> Id_Estado_Comparescencia_DPJ { get; set; }
        public Nullable<byte> Id_Estado_Comparescencia_DPM { get; set; }
        public Nullable<byte> Id_Situacion_Juridica_DPM { get; set; }
        public Nullable<byte> Id_Situacion_Juridica_DPJ { get; set; }
        public string alias { get; set; }
    }
}
