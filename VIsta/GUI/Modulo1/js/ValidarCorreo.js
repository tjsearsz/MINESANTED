$(document).ready(function () {
        $("input").keyup(function (event) {
            var arroba = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;

            if (arroba.test($("#RestablecerCorreo").val().trim())) {
                $("#mail").addClass("has-success");
                $("#mail").addClass("has-feedback");
                $("#restab").removeAttr("disabled")
            } else {
                $("#mail").removeClass("has-success");
                $("#mail").removeClass("has-feedback");
                $("#restab").attr("disabled", true)
            }
        });
});


