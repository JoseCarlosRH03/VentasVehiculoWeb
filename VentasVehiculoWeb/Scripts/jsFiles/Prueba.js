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



});

