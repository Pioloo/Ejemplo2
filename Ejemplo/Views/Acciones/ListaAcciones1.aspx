<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Master.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Ejemplo.Models.Ca_AccionesProcesales>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenido" runat="server">


<h2>Lista acciones procesales</h2>

<p>
    <%: Html.ActionLink("Crear nueva acción", "NuevaAccionProcesal") %>
</p>
<table id="tableOne" class="bordered-table zebra-striped" width="100%" style="margin: 1% auto;">
    <thead>
        <tr>
            <td class="tableHeader" colspan="5">
                    Nueva acción procesal<a href="/Acciones/NuevaAccionProcesal">
                        <img src="../../Content/Table/Mas.png" width="32px" height ="32px" class="ImgNuevo" title="Nueva cena"
                            alt="Dar de alta nueva cena" /></a>
                </td>
                <td colspan="5" class="filter" style="border-right: solid 1px #7f7f7f;">
                    Buscar: <input name="text"  value="" maxlength="30" size="30" type="text" />
                    <img id="filterClearOne" src="../../Content/Table/cross.png" width="32px"  style="cursor:pointer" height ="32px" title="Clic para limpiar el filtro."
                        alt="Clear Filter Image" />   
                </td>
            </tr>
        <tr>
            <th>
                Tìtulo
            </th>
            <th>
                Fecha del evento
            </th>
            <th>
                Descripción
            </th>
            <th>
                Patrocinado por
            </th>
            <th>
                Teléfono de contacto
            </th>
            <th>
                Dirección
            </th>
            <th>
                Ciudad
            </th>
            <th>
                Latitud
            </th>
            <th>
                Longitud
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
        <% foreach (var item in Model) { %>
            <tr>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Id_Etapa_Procesal) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Id_SubEtapa_Procesal) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Id_Accion) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.id_AccionProcesal) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Descripcion) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Usu_Act) %>
                </td>
                <td>
                    <%: Html.DisplayFor(modelItem => item.Fecha_Act) %>
                </td>
                <td>
                    <%: Html.ActionLink("Editar", "EditarAccion", new { /* id=item.PrimaryKey */ }) %> |
                    <%: Html.ActionLink("Ver detalles", "DetallesAccion", new { id=item.Id_Accion}) %> |
                    <%: Html.ActionLink("Borrar", "Delete", new { id=item.Id_Accion }) %>
                </td>
            </tr>
        <% } %>
    </tbody>
        <tfoot>
            <tr id="pagerOne">
                <td colspan="10" style="border-right: solid 1px #7f7f7f;">
                    <img src="../../Content/Table/first.png" class="first" alt="" width="32px" height ="32px" style="cursor:pointer" />
                    <img src="../../Content/Table/prev.png" class="prev" alt="" width="32px" height ="32px" style="cursor:pointer"/>
                    <input type="text" class="pagedisplay" />
                    <img src="../../Content/Table/next.png" class="next" alt="" width="32px" height ="32px" style="cursor:pointer"/>
                    <img src="../../Content/Table/last.png" class="last" alt="" width="32px" height ="32px" style="cursor:pointer"/>
                    <select class="pagesize">
                        <option selected="selected" value="10">10</option>
                    </select>
                </td>
            </tr>
        </tfoot>
</table>

    <script src="../../Scripts/jquery.tablesorter.js"></script>
    <script src="../../Scripts/jquery.tablesorter.pager.js"></script>
    <script src="../../Scripts/jquery.tablesorter.widgets.js"></script>
    <link href="../../Content/Table_Style.css" rel="stylesheet" />
    <link href="../../Content/TableSorterStyle.css" rel="stylesheet" />
    <link href="../../Content/TableStyle.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.tablesorter.filer.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            /*$("#tableOne").tablesorter({ debug: false, sortList: [], widgets: ['zebra'] })
                            .tablesorterPager({ container: $("#pagerOne"), positionFixed: false })
                            .tablesorterFilter({
                                filterContainer: $("#filterBoxOne"),
                                filterClearContainer: $("#filterClearOne"),
                                filterColumns: [0, 1, 2, 3],  // Agregar tantos como campos necesarios
                                filterCaseSensitive: false
                            });*/
            
        });
    </script>        
</asp:Content>
