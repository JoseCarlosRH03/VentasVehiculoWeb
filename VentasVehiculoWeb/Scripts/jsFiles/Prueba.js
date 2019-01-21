$(document).ready(function () {

    $(".fileUpload").on("change", function () {
        var files = $(this).get(0).files;
        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        uploadFiles(formData);
    });
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

    /* cargar imagenes */
    //$(document).ready(function () {
      
    //});

  
    function uploadFiles(formData) {
        $.ajax({
            url: UrlUpload,
            method: "POST",
            data: formData,
            dataType: 'Json',
            processData: false,
            contentType: false,
            success: function (data) {
                var str = "";
               

                for (var i = 0; i < data.length; i++) {
                    str += "<img class='img - fluid' alt='Responsive image' src='" + data[i] + "' height='100' width='100'>";
                }
                var jose = JSON.stringify(data);
                console.log(jose);
                $(".file-upload-container").append(str);
            },
            error: function (data) {
                alert("Upload Failed!");
            }
        });
    }
    //
});

