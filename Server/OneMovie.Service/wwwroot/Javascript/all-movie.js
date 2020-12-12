$(document).ready(function () {
    var allMovieJs = new AllMoVieJS();
})

class AllMoVieJS {
    constructor() {
        this.loadData(1);
        $(".blog-pagenat-wthree").on("click", "#paging li a", this.gotoPaging.bind(this));
        var seft = this;
    }
	htmlAppend(TenPhim, NamXb) {
        return $(`<div class="col-md-2 w3l-movie-gride-agile">
                    <a href="single.html" class="hvr-shutter-out-horizontal">
                        <img src="/Assets/images/m7.jpg" title="album-name" alt=" " />
                        <div class="w3l-action-icon"><i class="fa fa-play-circle" aria-hidden="true"></i></div>
                    </a>
                    <div class="mid-1">
                        <div class="w3l-movie-text">
                            <h6><a href="single.html">`+ TenPhim + `</a></h6>
                        </div>
                        <div class="mid-2">
                            <p>`+ commonJS.getYear(NamXb) + `</p>
                            <div class="block-stars">
                                <ul class="w3l-ratings">
                                    <li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-star" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-star-half-o" aria-hidden="true"></i></a></li>
                                    <li><a href="#"><i class="fa fa-star-o" aria-hidden="true"></i></a></li>
                                </ul>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <div class="ribben two">
                        <p>NEW</p>
                    </div>
                </div>`
		);
    }


    gotoPaging(e) {
        let page = e.currentTarget.innerText;
        this.loadData(page);
    }

    loadData(page) {
        let data;
        let promise = BaseAPI.Get('/api/PhanPhims/GetByPaging?page=' + page + '&&record=' + 12);
        promise.then((res) => {
            if (res) {
                data = res.Data;
                if (res.TotalPage > 2) {
                    $('#paging').empty();
                    if (page == 1) {
                        $('#paging').append($(`<li id="pageFirst"><a  class="frist">Đầu</a></li>`));
                        $('#paging').append($(`<li><a> << </a></li>`));
                        $('#paging').append($(`<li><a class="active-page">1</a></li>`));
                        $('#paging').append($(`<li><a>2</a></li>`));
                        $('#paging').append($(`<li><a>3</a></li>`));
                        $('#paging').append($(`<li><a> >> </a></li>`));
                        $('#paging').append($(`<li id="pageLast"><a  class="last">Cuối</a></li>`));
                    } else if (page == res.TotalPage) {
                        $('#paging').append($(`<li id="pageFirst"><a class="frist">Đầu</a></li>`));
                        $('#paging').append($(`<li><a> << </a></li>`));
                        $('#paging').append($(`<li><a>` + (Number(page) - 2) + `</a></li>`));
                        $('#paging').append($(`<li><a>` + (Number(page) - 1) + `</a></li>`));
                        $('#paging').append($(`<li><a class="active-page">` + page + `</a></li>`));
                        $('#paging').append($(`<li><a> >> </a></li>`));
                        $('#paging').append($(`<li id="pageLast"><a class="last">Cuối</a></li>`));
                    } else {
                        $('#paging').append($(`<li id="pageFirst"><a class="frist">Đầu</a></li>`));
                        $('#paging').append($(`<li><a> << </a></li>`));
                        $('#paging').append($(`<li><a>` + (Number(page) - 1) + `</a></li>`));
                        $('#paging').append($(`<li><a class="active-page">` + page + `</a></li>`));
                        $('#paging').append($(`<li><a>` + (Number(page) + 1) + `</a></li>`));
                        $('#paging').append($(`<li><a> >> </a></li>`));
                        $('#paging').append($(`<li id="pageLast"><a class="last">Cuối</a></li>`));
                    }
                    $('#pageFirst').data('pageNum', 1);
                    $('#pageFirst').data('pageNum', res.TotalPage);
                }
                



                $('.browse-inner').empty();
                for (let i = 0; i < 6; i++) {
                    $('.browse-inner').append(this.htmlAppend(data[i].TenPhim, data[i].NamXb));
                }
                $('.browse-inner-come-agile-w3').empty();
                for (let i = 6; i < 12; i++) {
                    $('.browse-inner-come-agile-w3').append(this.htmlAppend(data[i].TenPhim, data[i].NamXb));
                }
            }
        })
    }
}