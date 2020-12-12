
$(document).ready(function () {
    var account = new AccountJS();
})

class AccountJS {
    constructor() {
        this.initEvents();
    }

    initEvents() {
        $("#btnDangKy").click(this.btnDangKyOnClick.bind(this));
        $("#btnDangNhap").click(this.btnDangNhapOnClick.bind(this));
    }

    /**
     * Create by: BTTu (12/12/2020)
     * */
    btnDangKyOnClick() {
        let obj = {};
        let fields = $(".form.SignUp input");
        $.each(fields, function (index, field) {
            var fieldName = $(field).attr('fieldname');
            obj[fieldName] = $(field).val();
        })
        let promise = BaseAPI.Post('/api/TaiKhoans', obj);
        promise.then((res) => {
            if (res.Success) {
                $('#alert-res').html("Đăng ký thành công");
                $('#alert-res').removeClass('alert-danger');
                $('#alert-res').addClass('alert-success');
                $('#alert-res').show();

                //Tự đăng nhập sau 1.5 giây
                setTimeout(() => {
                    $('#myModal').modal('hide');
                    $('#userName').val(obj.TaiKhoan1);
                    $('#passWord').val(obj.MatKhau);
                    this.btnDangNhapOnClick();
                }, 1500);

            } else {
                $('#alert-res').html(res.Message);
                $('#alert-res').removeClass('alert-success');
                $('#alert-res').addClass('alert-danger');
                $('#alert-res').show();
            }
        })
    }

    /**
     * Create by: BTTu (12/12/2020)
     * */
    btnDangNhapOnClick() {
        let obj = {};
        debugger;
        let fields = $(".form.SignIn input");
        $.each(fields, function (index, field) {
            var fieldName = $(field).attr('fieldname');
            obj[fieldName] = $(field).val();
        })
        try {
            $.ajax({
                url: '/api/TaiKhoans/' + obj.TaiKhoan1 + '/' + obj.MatKhau,
                method: "GET",
                contentType: "application/json",
                dataType: "json",
                async: false
            }).done((res) => {
                if (res.Success) {
                    $(".userShow").empty();
                    let hmlt = $(`<a href="#">` + res.Data.TaiKhoan1 + `</a>`)
                    $(".userShow").append(hmlt);
                    $('#myModal').modal('hide');
                } else {
                    $('#alert-err').html(res.Message);
                    $('#alert-err').show();
                }
            }).fail((err) => {
            })
        } catch{
            console.log("Có lỗi");
        }
        
    }
}