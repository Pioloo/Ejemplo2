using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ejemplo.Models
{
    public class Estaticos
    {
        public static SelectList ListaSubEtapas(int? Etapa)
        {
            BD_DefensoriaOficio_PruebasEntities db = new BD_DefensoriaOficio_PruebasEntities();
            if (Etapa.HasValue)
            {
                return new SelectList(db.Ca_AccionesProcesales.Where(x => x.Id_Etapa_Procesal == Etapa && x.Id_Accion == 0), "Id_SubEtapa_Procesal", "Descripcion");
            }
            else
            {
                var etapas = db.Ca_AccionesProcesales.Where(x => x.Id_Accion == 0 && x.Id_SubEtapa_Procesal == 0);
                return new SelectList(etapas, "Id_Etapa_Procesal", "Descripcion");
            }
        }
        public static SelectList ListaEtapas()
        {
            BD_DefensoriaOficio_PruebasEntities db = new BD_DefensoriaOficio_PruebasEntities();
            var etapas = db.Ca_AccionesProcesales.Where(x => x.Id_Accion == 0 && x.Id_SubEtapa_Procesal == 0);
            return new SelectList(etapas, "Id_Etapa_Procesal", "Descripcion");
        }
    }
}