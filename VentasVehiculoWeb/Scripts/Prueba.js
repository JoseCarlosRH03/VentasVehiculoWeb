$(document).ready(function () {

    $("select option:first-child").attr('disabled', 'disabled');

    $(document).on("change", "#Id_Marca", function () {
        var opciones = null;

        $(".quitar").remove();

        var id = parseInt($(this).val());
        $.ajax({

            type: "POST",
            url: UrlMcarcaModelo,
            data: { valor: id },
            dataType: 'Json',

            done: function (data) {

            },
            success: function (data) {
                $("#quitar2").removeAttr("disabled");
                opciones = JSON.parse(data);

                for (var x = 0; x <= opciones.length; x++) {
                    $(".modelo").append("<option class='quitar' value='" + opciones[x].id + "'>" + opciones[x].Name + "</option>");
                }


            },
            error: function (xhr, request, status, error) {
                alert(xhr.status);
                alert(request.responseText);
            }
        });
    });
});

