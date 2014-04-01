
var ajaxJson = function (URL, DATA, dr, seleccion, callback) {
    $.ajax({
        type: "POST",
        datatype: "json",
        url: URL,
        data: DATA,
        success: function(result) {
            var call = $.Callbacks();
            call.add(callback);
            call.fire(result, dr, seleccion);
        },
        error: function(result) {
            alert(result.responseText);
        }
    });
}

var callBackLlenarSelect = function(result, dr, seleccion) {
    $("#" + dr).empty();
    if (result.length != 0) {
        $("#" + dr).append("<option value=0>Seleccione...</option>");
        $.each(result, function(i, item) {
            $("#" + dr).append("<option value='" + item.Value + "'>" + item.Text + "</option>");
        });
        $("#" + dr).val(seleccion);
    }
    else {
        $("#" + dr).append("<option value='0'>--Sin Resultados--</option>");
    }
}