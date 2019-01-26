
$(document).ready(function () {

    var opciones = null;
    // imagenes  del vehiculo
    $(".fileUpload").on("change", function () {
        var files = $(this).get(0).files;
        var formData = new FormData();
        for (var i = 0; i < files.length; i++) {
            formData.append(files[i].name, files[i]);
        }

        uploadFiles(formData);
    }); 

    /* cargar imagenes */
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
                opciones = data;

                for (var i = 0; i < data.length; i++) {
                    str += "<img class='img - fluid' alt='Responsive image' src='" + data[i] + "' height='100' width='100'>";
                }

                $(".file-upload-container").append(str);
            },
            error: function (data) {
                alert("Upload Failed!");
            }
        });
    }


    $("form").submit(function (event) {
        console.log($(this).serializeArray());
        console.log(opciones);
        event.preventDefault();
    });

});
