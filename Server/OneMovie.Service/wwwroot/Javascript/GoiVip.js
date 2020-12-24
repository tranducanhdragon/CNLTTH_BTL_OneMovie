$(document).ready(function () {
    var goivip = new GoiVipJS();
})
class GoiVipJS {
	constructor() {
		this.initEvents();
	}

	initEvents() {
		$("#MuaVip").click(this.GoiVipLoadData.bind(this));
	}

	htmlAppend(Idgoi, TenGoi, ThoiGian, GiaTien) {
		return $(`<div class="col-md-5 col-lg-4">
					<div class="item">
						<div class="heading">
							<h3>`+ TenGoi + `</h3>
						</div>
						<p>Giảm 0% khi mua vip</p>
						<div class="features">
							<h4><span class="feature">Xem Full phim</span> : <span class="value">Yes</span></h4>
							<h4><span class="feature">Thời hạn</span> : <span class="value" name="ThoiGian">`+ ThoiGian + ` Ngày</span></h4>
						</div>
						<div class="price" name="GiaTien">
							<h4>`+ GiaTien + ` VNĐ</h4>
						</div>
						<button class="btn btn-block btn-primary" onclick="MuaVip(`+ Idgoi +`)">Mua</button>
					</div>
				</div>`);
	}

	GoiVipLoadData() {
		let GoiVip = BaseAPI.Get('/api/GoiVips');
		GoiVip.then((res) => {
			if (res) {
				$('#GoiVip').empty();

				$.each(res, (index, item) => {
					$('#GoiVip').append(this.htmlAppend(item.Idgoi, item.TenGoi, item.ThoiGian, item.GiaTien));
				});
			}
		});
	}
	
}
function MuaVip(IdGoi) {
	let tk = JSON.parse(localStorage.getItem("TaiKhoan"));
	let obj = {};
	obj.TaiKhoan = tk.TaiKhoan1;
	obj.Idgoi = IdGoi;
	let muavip = BaseAPI.Post('/api/MuaVips', obj)
	muavip.then((res) => {
		if (res) {
			alert("Đã Đăng Ký Gói " + obj.Idgoi);
		}
	})
}