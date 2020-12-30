
$(document).ready(function () {
    var account = new AccountJS();
})

class AccountJS {
    constructor() {
        this.initEvents();
        this.afterLogin();
    }

    initEvents() {
        $("#btnDangKy").click(this.btnDangKyOnClick.bind(this));
        $("#btnDangNhap").click(this.btnDangNhapOnClick.bind(this));
        $(".w3l_sign_in_register").on('click','#logout',this.btnLogoutOnClick.bind(this));
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
        let fields = $(".form.SignIn input");
        $.each(fields, function (index, field) {
            var fieldName = $(field).attr('fieldname');
            obj[fieldName] = $(field).val();
        })
        let promise = BaseAPI.GetByID('/api/TaiKhoans/' + obj.TaiKhoan1, obj.MatKhau);
        promise.then((res) => {
            if (res.Success) {
                localStorage.setItem('TaiKhoan', JSON.stringify(res.Data));
                this.afterLogin();
                $('#myModal').modal('hide');
            }
            else {
                $('#alert-err').html(res.Message);
                $('#alert-err').show();
            }
        })
    }

    afterLogin() {
        let taiKhoan = JSON.parse(localStorage.getItem('TaiKhoan'));
        if (taiKhoan) {
            $(".userShow").hide();
            let html = $(`<h3>Xin chào <a href = "#" class="alert-link">` + taiKhoan.TaiKhoan1 + `</a></h3> <h4 id="logout"><a href = "#" class="alert-link">Đăng xuất</a></h4>`);
            $('#userName').empty();
            $('#userName').append(html);
            if (taiKhoan.LoaiTk == 0) {
                $('.buyVip').show();
            } else {
                $('.buyVip').hide();
            }
            $('#userName').show();
        } else {
            $(".userShow").show();
            $('#userName').hide();
            $('.buyVip').hide();
        }
        
    }
    btnLogoutOnClick() {
        localStorage.removeItem('TaiKhoan');
        console.log(localStorage);
        this.afterLogin();
    }
}