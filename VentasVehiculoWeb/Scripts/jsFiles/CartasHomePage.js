


$(document).ready(function () {

    $(".valorID").click(function () {
        event.preventDefault();


        var UrlSolicitar = $(".ruta").attr("href");
        var IdVehiculo = $(this).attr("href");
       
        SolicitarVehiculo(UrlSolicitar, IdVehiculo);

    });



    var SolicitarVehiculo = function (Url,idVal) {
        $.ajax({

            type: "POST",
            url: Url ,
            dataType: 'Json',
            data: { id: idVal},
            done: function (data) {

            },
            success: function (data) {

                if (data.indexOf("Home") >-1) {
                    window.location.href = data;
                } else {
                    alert(data);
                }

               

            },
            error: function (xhr, request, status, error) {
                alert(xhr.status);
                alert(request.responseText);
            }
        });
    };

});


