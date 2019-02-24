$(document).ready(function () {

   
    $(".valorID").click(function () {
        event.preventDefault();

        $.ajax({

            type: "POST",
            url: $(".ruta").attr("href"),
            dataType: 'Json',
            data: { id: $(this).attr("href")},
            done: function (data) {

            },
            success: function (data) {
                marcas = JSON.parse(data);

            },
            error: function (xhr, request, status, error) {
                alert(xhr.status);
                alert(request.responseText);
            }
        });

    });
});


