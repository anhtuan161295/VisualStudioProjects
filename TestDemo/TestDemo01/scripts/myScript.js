$("#btnLogin").click(function (e) {
    e.preventDefault();
    //Lấy dữ liệu từ input
    var data = {
        txtUsername: $("#txtUsername").val(),
        txtPassword: $("#txtPassword").val()
    };

    //alert($("#txtUsername").val() + $("#txtPassword").val());

    //Truyền dữ liệu JSON phải có dataType và contentType = JSON, ko là lỗi
    $.ajax({
        type: "POST",
        url: "/Logins/CheckLogin",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (response) {
            $("#errorMsg").removeClass();
            if (response == "User not found") {
                $("#errorMsgLogin").addClass("text-danger").html("User not found");
            }
            else if (response == "Wrong password") {
                $("#errorMsgLogin").addClass("text-danger").html("Wrong password");
            }
            else if (response == "Login success") {
                //$("#errorMsgLogin").addClass("text-success").html("Login success");
                location.reload();
            }
        }
    });
});

$("#btnRegister").click(function (e) {
    e.preventDefault();

    var name = $("#regUsername").val();
    var pass = $("#regPassword").val();
    var conpass = $("#regConfirmPassword").val();

    if (conpass != pass) {
        $("#errorMsgRegister").removeClass().addClass("text-danger").html("Confirm password and password don't match");
    }
    else if (name.length < 2 || name.length > 30) {
        $("#errorMsgRegister").removeClass().addClass("text-danger").html("Username length must be 2 to 30 characters");
    }
    else if (pass.length < 2 || pass.length > 30) {
        $("#errorMsgRegister").removeClass().addClass("text-danger").html("Password length must be 2 to 30 characters");
    } else {
        var data1 = {
            regUsername: name,
            regPassword: pass
        };

        $.ajax({
            type: "POST",
            url: "/Registers/Register",
            data: JSON.stringify(data1),
            dataType: "json",
            contentType: "application/json",
            success: function (response) {
                if (response == "Register success") {
                    $("#errorMsgRegister").removeClass().addClass("text-success").html("Register success");
                }
            }
        });
    }
});