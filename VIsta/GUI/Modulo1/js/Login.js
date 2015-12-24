$(document).ready(function () {
    $("input").keyup(function (event) {
        var arroba = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;

        if ($("#userIni").val() != "" && $("#passwordIni").val() != "") {
            $("#LoginButton").removeAttr("disabled");
        } else {
            $("#LoginButton").attr("disabled", true)
        }
    });
});