<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<Ejemplo.Models.Ca_AccionesProcesales>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">
    <link href="../../Content/TableSorterStyle.css" rel="stylesheet" />
    <div class="row">
				<div class="pedazo_verde row col-md-1 col-sm-1 col-xs-3">&nbsp;</div>	
				<div class="pedazo_naranja row col-md-2 col-sm-4 col-xs-4">
					<label class="paso_1">NUEVA</label>
					<label class="paso_1_1">acción procesal</label>
					<div class="triangulo hidden-xs">&nbsp;</div>
				</div>
				<div class="pedazo_verde row col-md-9 col-sm-7 col-xs-5">&nbsp;</div>
			</div>
			<div class="clearfix">
				&nbsp;
			</div>
			<div class="alert alert-personalizado">
				<i class="fa fa-warning fa-2x amarillo">&nbsp;</i><label class="fuente_roja">Nota:</label> Se requiere que la información proporcionada sea correcta para poder porporcionar un servicio de calidad
			</div>
            <div class="row">
				<div class="col-lg-6 col-md-5 col-sm-6 col-xs-0">&nbsp;</div>				
				<div class="col-lg-4 col-md-5 col-sm-6 col-xs-12">
					<a href="#" class="btn btn-success_modificado"><i class="fa fa-cloud-download alineacion_centrada">&nbsp;Descargar manual</i></a>
					<a href="#" class="btn btn-success_modificado"><i class="fa fa-envelope alineacion_centrada">&nbsp;Cont&aacute;ctanos&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</i></a>
				</div>
				<div class="col-lg-2 col-md-1 col-sm-0 col-xs-0">&nbsp;</div>
				<div class="col-lg-2 col-md-1 col-sm-0 col-xs-0">&nbsp;</div>
			</div>
			<br/>
			<div class="row">
				<form class="form-horizontal" action="NuevaAccionProcesal" method="post" id="frm_nva_accion_procesal">
					<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 control-label text-right">Etapa procesal:</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
                            <% var etapas = ViewData["etapas"] as List<Ejemplo.Models.Ca_AccionesProcesales>;  %>
                            <%: Html.DropDownList("Id_Etapa_Procesal",new SelectList(etapas,"Id_Etapa_Procesal","Descripcion"),"Seleccione","class='' required") %>
						</div>
					</div>
					<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 text-right control-label">Sub etapa procesal:</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
                            <select id="Id_SubEtapa_Procesal" name="Id_SubEtapa_Procesal"  required>
                                <option value="0">Seleccione...</option>
                            </select>
						</div>
					</div>
					<!--<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 text-right">Clave acción:</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
							<%: Html.EditorFor(model => model.Id_Accion) %>
						</div>
					</div>-->
					<!--<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 control-label text-right">Clave acción procesal:</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
							<%: Html.EditorFor(model => model.id_AccionProcesal) %>
						</div>
					</div>-->
					<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 text-right control-label">Descripción:</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
							<%: Html.EditorFor(model => model.Descripcion) %>
						</div>
					</div>
                    <!--<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 text-right control-label">¿Usuario activo?:</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
							<%: Html.EditorFor(model => model.Usu_Act) %>
						</div>
					</div>-->
					<div class="form-group">
						<label class="col-lg-4 col-md-3 col-sm-4 col-xs-6 text-right control-label">&nbsp;</label>
						<div class="col-lg-8 col-md-9 col-sm-8 col-xs-6">
							<input type="submit" id="guardar_accion" name="guardar_accion" class="btn btn-primary btn-margin" value="Guardar"/>
						</div>
					</div>
				</form>
			</div>
<div>
    <%: Html.ActionLink("Volver al inicio", "Index") %>
</div>
    <script src="../../Scripts/jquery.tablesorter.js"></script>
    <script src="../../Scripts/jquery.tablesorter.pager.js"></script>
    <script src="../../Scripts/jquery.tablesorter.widgets.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        $("#Id_Etapa_Procesal").on("change", function () {
            ajaxJson("/Acciones/ListaSubEtapas/", { Etapa: $(this).val() }, "Id_SubEtapa_Procesal", 0, callBackLlenarSelect);
        });
        $("#frm_nva_accion_procesal").submit(function (e) {
            e.preventDefault();
        });
        $("input#guardar_accion").click(function () {
            if (validar()) {
                $.ajax({
                    type: "POST",
                    url: "/Acciones/NuevaAccionProcesal",
                    data: $("#frm_nva_accion_procesal").serialize(),
                    success: function (result) {
                        if (result.Exito == false) {
                            alert(result.Message);
                        } else {
                            $("#frm_nva_accion_procesal")[0].reset();
                            alert("Insertado correctamente");
                            window.open("/Acciones/ListaAcciones", "_self");
                        }
                    }
                });
            } else return false;
        });
    });
    function validar() {
        if ($("#Id_Etapa_Procesal").val() == 0) {
            $("#Id_Etapa_Procesal").focus();
            alert("Seleccione la etapa procesal");
            return false;
        }
        else if ($("#Id_SubEtapa_Procesal").val() == 0) {
            $("#Id_SubEtapa_Procesal").focus();
            alert("Seleccione la sub etapa procesal");
            return false;
        }
        else if ($("#Descripcion").val() == "") {
            $("#Descripcion").focus();
            alert("Ingrese descripción");
            return false;
        }
        else return true;
    }
</script>
</asp:Content>
