var idVehculo = 0;
$(document).ready(function () {

    var modelos = null;
    var traccion = null;
    var textModelo = null;



    //ajax de los modelos
    $(document).on("change", ".marca", function () {


        $(".quitar").remove();
        $(".modelo").val('*');
        var id = parseInt($(this).val());

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
                modelos = opciones;
                if (opciones.length === 0) {
                    alert("no hay datos");
                } else {


                    var precentar = null;
                    for (var x = 0; x <= opciones.length; x++) {
                        var modelo = $(".modelo option");


                        for (var i = 0; i <= (modelo.length - 1); i++) {

                            if (opciones[x]["Name"] === modelo[i].text) {
                                precentar = false;
                            } else {
                                precentar = true;
                            }
                        }

                        if (precentar) {
                            $(".modelo").append("<option class='quitar' value='" + opciones[x]["Id"] + "'>" + opciones[x]["Name"] + "</option>");
                        }


                    }

                }


            },
            error: function (xhr, request, status, error) {
                alert(xhr.status);
                alert(request.responseText);
            }
        });
    });


    //ajax de los traccion
    $(document).on("change", ".modelo", function () {

        textModelo = $(this).children("option:selected").text();
        $(".quitar3").remove();

        if (traccion !== null) {
            TraccionAjax(traccion);
        } else {

            $.ajax({

                type: "POST",
                url: UrlTraccion,
                dataType: 'Json',

                done: function (data) {

                },
                success: function (data) {
                    $("#quitar4").removeAttr("disabled");
                    opciones = JSON.parse(data);
                    TraccionAjax(opciones);
                },
                error: function (xhr, request, status, error) {
                    alert(xhr.status);
                    alert(request.responseText);
                }
            });
        }


    });


    function TraccionAjax(opciones) {

        traccion = opciones;
        if (opciones.length === 0) {
            alert("no hay datos");
        } else {

            for (var x = 0; x <= modelos.length; x++) {

                if (modelos[x].Name === textModelo) {

                    for (var i = 0; i < opciones.length; i++) {

                        if (modelos[x].Traccion === opciones[i].Id) {

                            $(".traccion").append("<option class='quitar3' value='" + opciones[i].Id + "'>" + opciones[i].Nombre + "</option>");
                        }
                    }
                }
            }
        }


    };




    var opciones = null;
    $("form").submit(function (event) {

        var formulario = $(this).serializeArray();


        event.preventDefault();

        if (formulario.length < 12) {

            alert("Por favor complete los campor faltantes");
        } else if (opciones !== null) {


                    for (var x = 0; x <= modelos.length; x++) {
                        if (textModelo === modelos[x].Name && parseInt(formulario[10].value) === modelos[x].Traccion) {
                            var IdModelo = modelos[x].Id;
                            break;
                        }
                    }

                    $.ajax({
                        type: "POST",
                        url: UrlCreate,
                        data: {
                            "precio": parseFloat(formulario[1].value),
                            "Kilometraje": parseFloat(formulario[2].value),
                            "Color": formulario[3].value,
                            "Año": formulario[4].value,
                            "Id_Combustible": parseInt(formulario[9].value),
                            "Id_TipoVehiculo": parseInt(formulario[12].value),
                            "Id_Asiento": parseInt(formulario[11].value),
                            "Id_Estado": parseInt(formulario[5].value),
                            "Id_Modelo": parseInt(IdModelo),
                            "Id_Suplidor": parseInt(formulario[8].value)

                        }, success: function (data) {
                            idVehculo = JSON.parse(data);
                            location.href = UrlCreateImagen + "?IdVal=" + idVehculo;
                        },
                        error: function (data) {
                            alert("Upload Failed!");
                        }
                    });

                } else {
                 alert("Introduzca por lo meno una imagen del ehiculo");
               }

    });


});


