$(document).ready(function () {
    // deshabilita el estado del vehiculo si kilometraje es 0 o mayor
    $("select option:first-child").attr('disabled', 'disabled');

    $(document).on("change", ".kilometraje", function () {

        if (parseInt($(this).val())!== 0) {
            $("#Id_Estado option[value='1']").attr('disabled', 'disabled');
            $("#Id_Estado option[value='2']").removeAttr('disabled');
            $(".estado").val(2);
        } else {
            $("#Id_Estado option[value = '2']").attr('disabled', 'disabled');
            $("#Id_Estado option[value = '1']").removeAttr('disabled');
            $(".estado").val(1);
        }
    });

    $("#aqui").click(function () {
        $('html, body').animate({
            scrollTop: $(".parca").offset().top
        }, 1500);
    });
   
});

