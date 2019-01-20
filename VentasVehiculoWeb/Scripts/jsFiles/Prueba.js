$(document).ready(function () {

   
    var marcas = null;
    // cargar las  marcas 
    $.ajax({

        type: "POST",
        url: UrlMarca,
        dataType: 'Json',

        done: function (data) {

        },
        success: function (data) {
            marcas = JSON.parse(data);
            //Console.log(marcas);
            if (marcas.length === 0) 
            {
                alert("no hay marcas en la DB");
            } else {
                for (var x = 0; x <= (marcas.length - 1); x++) {
                    $(".marca").append("<option value='" + marcas[x].Id + "'>" + marcas[x].Name + "</option>");
                } 
            }
        },
        error: function (xhr, request, status, error) {
            alert(xhr.status);
            alert(request.responseText);
        }
    });

    //ajax de los modelos
    $(document).on("change", ".marca", function () {
        var opciones = null;

        $(".quitar").remove();

        var id = parseInt($(this).val());
        console.log(id);
        $.ajax({

            type: "POST",
            url: UrlMarcaModelo,
            data: { valor: id },
            dataType: 'Json',

            done: function (data) {

            },
            success: function (data) {
                $("#quitar2").removeAttr("disabled");
                opciones = JSON.parse(data);

                if (opciones.length === 0) {
                    alert("no hay datos");
                } else {
                    for (var x = 0; x <= opciones.length; x++) {
                        $(".modelo").append("<option class='quitar' value='" + opciones[x].Id + "'>" + opciones[x].Name + "</option>");
                    }
                }
                

            },
            error: function (xhr, request, status, error) {
                alert(xhr.status);
                alert(request.responseText);
            }
        });
    });


    
});

