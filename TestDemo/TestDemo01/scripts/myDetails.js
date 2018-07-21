//Khi bất cứ thẻ a nào có id bắt đầu = btnDetails và bấm click thì chạy function này
$("[id^=btnDetails]").click(function (e) {
    e.preventDefault();
    //Lấy id từ thuộc tính title của thẻ a trong html
    var id = $(this).attr('title');
    //alert(id);

    var data = { id: id };

    $.ajax({
        type: "POST",
        url: "/Users/Details",
        data: JSON.stringify(data),
        dataType: "json",
        contentType: "application/json",
        success: function (data) {
            if (data != null) {
                var msg = "User Id:" + data.UserId + "<br>" + "User Name:" + data.Username + "<br>" + "Password:" + data.Password + "<br>";
                $("#modalBody").html(msg);
                $("#modalDetails").modal("show");
            }
        }
    });
});