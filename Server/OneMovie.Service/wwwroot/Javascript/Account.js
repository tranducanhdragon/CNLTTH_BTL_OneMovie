
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
                $("#myModal , .modal-backdrop.fade.in").hide();
            } else {
                alert(res.Message)
            }
        })
    }

    btnDangNhapOnClick() {
        let obj = {};
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
                    $("#myModal").removeClass('in');
                    $('.modal-backdrop').remove();
                } else {
                    alert(res.Message)
                }
            }).fail((err) => {
            })
        } catch{
            console.log("Có lỗi");
        }
        
    }
}