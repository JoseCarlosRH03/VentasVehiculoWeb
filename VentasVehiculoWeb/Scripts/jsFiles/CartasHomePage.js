$(document).ready(function () {

    $("a").click(function () {
        event.preventDefault();

        // cargar las  marcas 
        //$.ajax({

        //    type: "POST",
        //    url: UrlComprar,
        //    dataType: 'Json',
        //    data: { id: $(this).attr("href")},
        //    done: function (data) {

        //    },
        //    success: function (data) {
        //        marcas = JSON.parse(data);

        //    },
        //    error: function (xhr, request, status, error) {
        //        alert(xhr.status);
        //        alert(request.responseText);
        //    }
        //});

    });
});


