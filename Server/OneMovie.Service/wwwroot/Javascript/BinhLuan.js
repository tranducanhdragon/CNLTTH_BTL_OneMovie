$(document).ready(function () {
    var binhluan = new BinhLuanJS();
})

class BinhLuanJS {
    constructor() {
        this.initEvents();        
    };

    initEvents() {
        let url = window.location.href;
        let MaPhim = url.substring(url.lastIndexOf('=') + 1);
        this.HienThiBinhLuan(MaPhim);
        $("#btnBinhLuan").click(this.GuiBinhLuan.bind(this));
    };

    loadBinhLuan(TaiKhoan, NoiDung) {
        return $(`<div class="media">
					<h5>`+ TaiKhoan +`</h5>
					<div class="media-left">
						<a href="#">
							<img src="/Assets/images/user.jpg" title="One movies" alt=" " />
						</a>
					</div>
					<div class="media-body">
						<p>`+ NoiDung +`</p>
						<span>View all posts by :<a href="#"> Admin </a></span>
					</div>
				</div>`);
    }

    GuiBinhLuan() {
        debugger;
        let bl = {};
        //Lấy dữ liệu các thẻ input trong class agile-info-wthree-box gồm tên, mail, sđt, nội dung
        let inputBinhLuan = $('.agile-info-wthree-box input');
        $.each(inputBinhLuan, function (index, field) {
            var fieldname = $(field).attr('fieldname');
            bl[fieldname] = $(field).val();
        })
        //Tạo đối tượng BinhLuan bình luận lên
        
        let obj = {};
        let url = window.location.href;
        let tk = JSON.parse(localStorage.getItem("TaiKhoan"));
        obj.TaiKhoan = tk.TaiKhoan1;
        obj.MaPhim = url.substring(url.lastIndexOf('=') + 1);
        obj.NoiDung = $('.agile-info-wthree-box textarea').val();

        //Post BinhLuan lên
        let bl_promise = BaseAPI.Post('/api/BinhLuans', obj);
        bl_promise.then((res) => {
            if (res) {
                window.location.href = url;
            }
        })

    }

    HienThiBinhLuan(MaPhim) {
        let bl = BaseAPI.GetByID('/api/BinhLuans', MaPhim);
        bl.then((res) => {
            if (res) {
                $('.media-grids').empty();
                $.each(res.Data, (index, item) => {
                    $('.media-grids').append(this.loadBinhLuan(item.TaiKhoan, item.NoiDung))
                })
                $('.media-grids').show();
                
            }
        })
    }
}