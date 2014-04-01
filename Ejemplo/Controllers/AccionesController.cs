using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ejemplo.Models.Repositorios;
using Ejemplo.Models;
using MvcRazorToPdf;
using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Point = DotNet.Highcharts.Options.Point;
namespace Ejemplo.Controllers
{
    public class AccionesController : Controller
    {
        //
        // GET: /Acciones/
        RepoDenfensoria repo = new RepoDenfensoria();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grafica()
        {
            Highcharts chart = new Highcharts("chart")
                 .InitChart(new Chart { DefaultSeriesType = ChartTypes.Line})
                 .SetTitle(new Title { Text = "Acciones procesales" })
                 .SetSubtitle(new Subtitle { Text = "" })
                 .SetXAxis(
                 new XAxis{
                     Categories = new[] { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre" }
                 })
                 .SetYAxis(new YAxis { Title = new YAxisTitle { Text = "Cantidad" }, Labels = new YAxisLabels { Formatter = "function() { return Highcharts.numberFormat(this.value, 0);}" } })
                 .SetPlotOptions(new PlotOptions
                 {
                     Area = new PlotOptionsArea
                     {
                         Marker = new PlotOptionsAreaMarker
                         {
                             Enabled = false,
                             Symbol = "circle",
                             Radius = 2,
                             States = new PlotOptionsAreaMarkerStates
                             {
                                 Hover = new PlotOptionsAreaMarkerStatesHover { Enabled = true }
                             }
                         }
                     }
                 })
                 .SetSeries(new []
                                { new Series { Name = "Colima", Data = new Data(new object[] { 5, 3, 4, 7, 2, 5, 8, 4,6,4,3,8}) },
                                  new Series { Name = "Jalisco", Data = new Data(new object[] { 2, 6, 9, 2, 1, 5, 8, 2,6,2,5,9 })} ,
                                  new Series { Name = "Michoacán", Data = new Data(new object[] { 2, 5, 23, 10, 4, 23, 4,1,4,2,8,7 })}
                                });

            return View(chart);
        }

        public ActionResult ListaAcciones(int? Etapa, int? SubEtapa)
        {
           // return new PdfActionResult("ListaAcciones2",repo.ListAccionesProcesales(Etapa, SubEtapa));
            return View(repo.ListAccionesProcesales(Etapa, SubEtapa));
        }
        public ActionResult ListaSubEtapas(int? Etapa)
        {
            //var etapas = repo.ListaEtapasDes();
            //ViewData["etapas"] = etapas;
            return View(repo.ListaSubEtapas(Etapa));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ListaSubEtapasList(int? Etapas)
        {
            try
            {
                return new JsonResult { Data = Ejemplo.Models.Estaticos.ListaSubEtapas(Etapas) };
            }
            catch
            {
                return new JsonResult { Data = false };
            }
        }
        //public ActionResult ListaSubEtapas2()
        //{
        //    var etapas = repo.ListaEtapasDes().ToList;
        //    ViewData["etapas"] = etapas;
        //    return View("ListaSubEtapas",etapas);
        //}
        public ActionResult ListaEtapas2()
        {
            return View(repo.ListaEtapas());
        }

        public ActionResult PdfAcciones(int? Etapa, int? SubEtapa)
        {
            return new PdfActionResult("ListaAcciones2",repo.ListAccionesProcesales(Etapa, SubEtapa));
        }

        public ActionResult EditarAccion(String Id_Accion)
        {
            var etapas = repo.ListaEtapas().ToList();
            ViewData["etapas"] = etapas;
            Ca_AccionesProcesales accion = repo.ObtenerAccionProcesal(Id_Accion);
            return View(accion);
        }
        public ActionResult EditarEtapa(String Id_Accion)
        {
            Ca_AccionesProcesales accion = repo.GetEtapa(Id_Accion);
            return View(accion);
        }
        public ActionResult EditarSubEtapa(String Id_Accion)
        {
            Ca_AccionesProcesales accion = repo.GetSubEtapa(Id_Accion);
            return View(accion);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        //[ValidateAntiForgeryToken]
        public ActionResult EditarAccion(Ca_AccionesProcesales accion)
        {
            try
            {
                Ca_AccionesProcesales temp = repo.ObtenerAccionProcesal(accion.id_AccionProcesal);
                if (temp.Id_Etapa_Procesal != accion.Id_Etapa_Procesal && temp.Id_SubEtapa_Procesal != accion.Id_SubEtapa_Procesal)
                    UpdateModel<Ca_AccionesProcesales>(temp);
                else
                {
                    temp.Descripcion = accion.Descripcion;
                    temp.Usu_Act = 1;
                    temp.Fecha_Act = DateTime.Now;
                    repo.GuardarCambios();
                }
                return Json(new { Exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarEtapa(Ca_AccionesProcesales accion)
        {
            try
            {
                Ca_AccionesProcesales temp = repo.GetEtapa(accion.id_AccionProcesal);
                temp.Descripcion = accion.Descripcion;
                temp.Fecha_Act = DateTime.Now;
                repo.GuardarCambios();
                
                return View("ListaEtapas2");
                //return Json(new { Exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message });
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult EditarSubEtapa(Ca_AccionesProcesales accion)
        {
            try
            {
                Ca_AccionesProcesales temp = repo.GetSubEtapa(accion.id_AccionProcesal);
                temp.Descripcion = accion.Descripcion;
                temp.Fecha_Act = DateTime.Now;
                repo.GuardarCambios();

                return View("ListaSubEtapas");
                //return Json(new { Exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message });
            }
        }

        public ActionResult NuevaAccionProcesal()
        {
            var etapas = repo.ListaEtapas().ToList();
            ViewData["etapas"] = etapas;
            return View();
        }

        public ActionResult NuevaEtapa()
        {
            return View();
        }
        public ActionResult NuevaSubEtapa()
        {
            var etapas = repo.ListaEtapas().ToList();
            ViewData["etapas"] = etapas;
            return View();
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NuevaAccionProcesal(Ca_AccionesProcesales accion, FormCollection form)
        {
            try
            {
                accion.Id_Accion = repo.NextAccion(accion.Id_Etapa_Procesal, accion.Id_SubEtapa_Procesal);
                accion.Fecha_Act = DateTime.Now;
                accion.Usu_Act = 1;
                repo.AgregarAccionProceal(accion);
                repo.GuardarCambios();
                return Json(new { Exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message });
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NuevaEtapa(Ca_AccionesProcesales accion, FormCollection form)
        {
            try
            {
                accion.Id_Etapa_Procesal = repo.NextEtapa();
                accion.Fecha_Act = DateTime.Now;
                accion.Usu_Act = 1;
                repo.AgregarEtapa(accion);
                repo.GuardarCambios();
                return Json(new { Exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message });
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NuevaSubEtapa(Ca_AccionesProcesales accion, FormCollection form)
        {
            try
            {
                accion.Id_SubEtapa_Procesal = repo.NextSubEtapa();
                accion.Fecha_Act = DateTime.Now;
                accion.Usu_Act = 1;
                repo.AgregarEtapa(accion);
                repo.GuardarCambios();
                return Json(new { Exito = true });
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message });
            }
        }
        public ActionResult EliminarAccion(String Id_Accion)
        {
            try
            {
                Ca_AccionesProcesales accion = repo.ObtenerAccionProcesal(Id_Accion);
                repo.EliminarAccion(accion);
                repo.GuardarCambios();
                return Json(new { Exito = true },JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { Exito = false, Mensaje = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DetallesAccion(String Id_Accion)
        {
            return View(repo.ObtenerAccionProcesal(Id_Accion));
        }
        public ActionResult DetallesEtapa(String Id_Accion)
        {
            return View(repo.GetEtapa(Id_Accion));
        }
        public ActionResult DetallesSubEtapas(String Id_Accion)
        {
            return View(repo.GetSubEtapa(Id_Accion));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ListaEtapas()
        {
            IQueryable<Ca_AccionesProcesales> Etapas = repo.ListaEtapas();
            SelectList ls = new SelectList(Etapas, "Id_Etapa_Procesal", "Descripcion");
            return new JsonResult { Data = ls };
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ListaSubetapas(int? Etapa)
        {
            IQueryable<Ca_AccionesProcesales> SubEtapa = repo.ListaSubEtapas(Etapa);
            SelectList ls = new SelectList(SubEtapa, "Id_SubEtapa_Procesal", "Descripcion");
            return new JsonResult { Data = ls };
        }

        public ActionResult vista()
        {
            return View();
        }

        public ActionResult Calendario() {

            return View();
        }

        //Acción para mostrar el colorbox con las horas del día seleccionado
        public ActionResult MuestraDia(String fecha){
            ViewData["dia"] = fecha;
            Response.Write(fecha);
            return View();
        }
    }

}
