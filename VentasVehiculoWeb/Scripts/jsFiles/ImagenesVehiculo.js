
$(document).ready(function () {

    $.urlParam = function (name) {
        var results = new RegExp('[\?&]' + name + '=([^&#]*)').exec(window.location.href);
        if (results === null) {
            return null;
        }
        return decodeURI(results[1]) || 0;
    };

    var parametroIdVehiculo = $.urlParam("IdVal");

    $(".DropDownListtImagenVehiculos option").remove();
    $(".DropDownListtImagenVehiculos").append("<option ' value='" + parametroIdVehiculo + "'>" + parametroIdVehiculo + "</option>");
    $(".DropDownListtImagenVehiculos").val(parametroIdVehiculo);
       
 
});


