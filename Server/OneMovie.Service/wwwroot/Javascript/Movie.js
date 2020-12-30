$(document).ready(function () {
    var movie = new MovieJS();
})

class MovieJS {
    constructor() {
        this.loadData();
    }

	
	htmlAppend(Idphim,TenPhim,NamXb) {
		return $(`<div class="col-md-2 w3l-movie-gride-agile">
					<a href="single.html?Idphim=`+ Idphim +`" class="hvr-shutter-out-horizontal">
						<img src="/Assets/MyImages/harry-potter-7-1.jpg" title="album-name" class="img-responsive" alt=" " />
						<div class="w3l-action-icon"><i class="fa fa-play-circle" aria-hidden="true"></i></div>
					</a>
					<div class="mid-1 agileits_w3layouts_mid_1_home">
						<div class="w3l-movie-text">
							<h6><a href="single.html?Idphim=`+ Idphim +`">` + TenPhim + `</a></h6>
						</div>
						<div class="mid-2 agile_mid_2_home">
							<p>`+ commonJS.getYear(NamXb) + `</p>
							<div class="block-stars">
								<ul class="w3l-ratings">
									<li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
									<li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
									<li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
									<li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
									<li><a href="#"><i class="fa fa-star-half-o" aria-hidden="true"></i></a></li>
								</ul>
							</div>
							<div class="clearfix"></div>
						</div>
					</div>
					<div class="ribben">
						<p>NEW</p>
					</div>
				</div>`
		);
    }

    loadData() {
        let data; 
        let promise = BaseAPI.Get('/api/PhanPhims');
        promise.then((res) => {
			if (res) {
				data = res;
				//#region Phim nổi bật
				//#region danh sách phim đặc sắc
				$('#home .w3_agile_featured_movies').empty(); //Xoa data cũ

				$.each(data, (index, item) => {
					$('#home .w3_agile_featured_movies').append(this.htmlAppend(item.MaPhim, item.TenPhim, item.NamXb));
				})
				//#endregion
				//#region danh sách phim top viewd (Lấy vài phim nhiều view nhất)

				$('#profile').empty();

				data = data.sort((a, b) => {
					if (a.LuotXem > b.LuotXem) return 1;
					else if (a.LuotXem < b.LuotXem) return -1;
					else return 0
				})

				for (let i = 0; i < 4; i++) {
					$('#profile').append(this.htmlAppend(data[i].TenPhim, data[i].NamXb));
				}
				//#endregion
                //#region danh sách phim top rating (Lấy vài phim nhiều đánh giá 5* nhất)

				$('#rating').empty();

				data = data.sort((a, b) => {
					if (a.DanhGia > b.DanhGia) return 1;
					else if (a.DanhGia < b.DanhGia) return -1;
					else return 0;
				})

				for (let i = 0; i < 5; i++) {
					$('#rating').append(this.htmlAppend(data[i].TenPhim, data[i].NamXb));
				}
				//#endregion
                //#region danh sách phim recently added (được thêm gần nhất)
				$("#imdb").empty();
				data = data.sort((a, b) => {
					if (a.NgayTao > b.NgayTao) return 1;
					else if (a.NgayTao < b.NgayTao) return -1;
					else return 0;
				})
				for (let i = 0; i < 5; i++) {
					$("#imdb").append(this.htmlAppend(data[i].TenPhim, data[i].NamXb));
				}
				//#endregion
				//#endregion 

				//#region Phim phổ biến
					
				//#endregion

            }
        })
	}

}