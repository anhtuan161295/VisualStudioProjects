$(document).ready(function () {
    $("#btnSubmitRegister").click(function (e) {
        e.preventDefault();
    });
    $("#registerUsername").blur(function (e) {
        e.preventDefault();
        var name = $("#registerUsername").val();
        if (name == "") {
            $("#errorRegisterUsername").html("<p>User name is required!</p>");
        }
    });
});