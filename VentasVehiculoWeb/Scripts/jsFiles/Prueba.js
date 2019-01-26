$(document).ready(function () {

    var marcas = null;
    var modelos = null;
    var traccion = null;
    var textModelo = null;
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
                        
                        
                        for (var i = 0; i <= (modelo.length-1); i++) {

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


});

