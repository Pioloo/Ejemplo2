using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ejemplo.Models;

namespace Ejemplo.Models.Repositorios
{
    public class RepoDenfensoria
    {
        public BD_DefensoriaOficio_PruebasEntities db;
        public RepoDenfensoria()
        {
            db = new BD_DefensoriaOficio_PruebasEntities();
        }

        public IQueryable<Ca_AccionesProcesales> ListAccionesProcesales(int? Etapa, int? SubEtapa)
        {
            if(Etapa.HasValue && SubEtapa.HasValue)
            {
                return db.Ca_AccionesProcesales.Where(x => x.Id_Etapa_Procesal == Etapa.Value && x.Id_SubEtapa_Procesal == SubEtapa.Value && x.Id_Accion != 0);
            }
            else if (Etapa.HasValue && !SubEtapa.HasValue)
            {
                return db.Ca_AccionesProcesales.Where(x => x.Id_Etapa_Procesal == Etapa.Value && x.Id_Accion != 0);
            }
            else
            {
                return db.Ca_AccionesProcesales.Where(x => x.Id_Accion != 0);
            }
        }

        public IQueryable<Ca_AccionesProcesales> ListaEtapas()
        {
            return db.Ca_AccionesProcesales.Where(x => x.Id_Accion == 0 && x.Id_SubEtapa_Procesal == 0);
        }
         public IQueryable<Ca_AccionesProcesales> ListaEtapasDes()
        {
             IQueryable<Ca_AccionesProcesales> des = db.Ca_AccionesProcesales.Where(x => x.Id_Accion == 0 && x.Id_SubEtapa_Procesal == 0).Select(x =>new Ca_AccionesProcesales(){Id_Etapa_Procesal = x.Id_Etapa_Procesal,Descripcion = x.Descripcion});
             return des;
        }

        public Ca_AccionesProcesales getSubEtapa(int Etapa)
        {
            return db.Ca_AccionesProcesales.SingleOrDefault(x => x.Id_Etapa_Procesal == Etapa && x.Id_SubEtapa_Procesal != 0);
        }

        public IQueryable<Ca_AccionesProcesales> ListaSubEtapas(int? Etapa)
        {
            if (Etapa.HasValue)
            {
                return db.Ca_AccionesProcesales.Where(x => x.Id_Etapa_Procesal == Etapa && x.Id_SubEtapa_Procesal != 0);
            }
            else
                return db.Ca_AccionesProcesales.Where(x => x.Id_Accion == 0 && x.Id_SubEtapa_Procesal != 0);
        }
        public void AgregarAccionProceal(Ca_AccionesProcesales accion)
        {
            db.Ca_AccionesProcesales.Add(accion);
        }
        public void AgregarEtapa(Ca_AccionesProcesales accion)
        {
            db.Ca_AccionesProcesales.Add(accion);
        }

        public void EliminarAccion(Ca_AccionesProcesales accion)
        {
            db.Ca_AccionesProcesales.Remove(accion);
        }

        public Ca_AccionesProcesales ObtenerAccionProcesal(string id_accion)
        {
            return db.Ca_AccionesProcesales.SingleOrDefault(x => x.id_AccionProcesal == id_accion);
        }
        //public IQueryable<Ca_AccionesProcesales> ObtenerEtapa(short id_accion)
        //{
        //    return db.Ca_AccionesProcesales.Where(x => x.Id_Etapa_Procesal == id_accion);
        //}
        public Ca_AccionesProcesales GetEtapa(string id_accion)
        {
            return db.Ca_AccionesProcesales.SingleOrDefault(x => x.id_AccionProcesal == id_accion);
        }
        public Ca_AccionesProcesales GetSubEtapa(string id_accion)
        {
            return db.Ca_AccionesProcesales.SingleOrDefault(x => x.id_AccionProcesal == id_accion);
        }
        

        public void GuardarCambios()
        {
            db.SaveChanges();
        }

        public byte NextAccion(Int16 Etapa, byte SubEtapa)
        {
            Int16 max = 0;
            try
            {
                max = (from reg in db.Ca_AccionesProcesales where reg.Id_Etapa_Procesal == Etapa && reg.Id_SubEtapa_Procesal == SubEtapa select reg.Id_Accion).Max();
            }
            catch
            {
                max = 0;
            }
            max++;
            return (byte)max;
        }
        public byte NextEtapa()
        {
            Int16 max = 0;
            try
            {
                max = (from reg in db.Ca_AccionesProcesales select reg.Id_Etapa_Procesal).Max();
            }
            catch
            {
                max = 0;
            }
            max++;
            return (byte)max;
        }
        public byte NextSubEtapa()
        {
            Int16 max = 0;
            try
            {
                max = (from reg in db.Ca_AccionesProcesales select reg.Id_SubEtapa_Procesal).Max();
            }
            catch
            {
                max = 0;
            }
            max++;
            return (byte)max;
        }
        
        
    }
}