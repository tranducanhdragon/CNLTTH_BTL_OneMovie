$(document).ready(function () {
    var baseJS = new BaseJS();
})

class BaseJS {
    constructor() {
        this.initEvents();
    }
    initEvents() {
        $("#btnDangNhap").click(this.btnDangNhapOnClick.bind(this));
    }
    btnDangNhapOnClick() {
        let obj = {};
        let fields = $(".card-body input");
        $.each(fields, function (index, field) {
            var fieldName = $(field).attr('fieldname');
            obj[fieldName] = $(field).val();
        })
        if (obj.TaiKhoan1 == 'admin' && obj.MatKhau == 'admin') {
            window.location.href = "./index.html"
        } else {
            $('#alert-err').html("Sai tên đăng nhập hoặc mật khẩu");
            $('#alert-err').show();
        }
    }
}