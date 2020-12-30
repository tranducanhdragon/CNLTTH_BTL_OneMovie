$(document).ready(function () {
    var phanphim = new PhanPhimJS();
})

class PhanPhimJS {
    constructor() {
        this.initEvents();
    };

    initEvents() {
        this.loadPhanPhim();
    };

    loadPhanPhim() {
        $('#tbodyPhanPhim').empty();
        var phanphim = BaseAPI.Get('/api/PhanPhims');
        phanphim.then(res => {
            if (res) {
                $.each(res, (index, item) => {
                    $('#tbodyPhanPhim').append(`<tr>
                                                <td>`+ item.TenPhim +`</td>
                                                <td>`+ item.Tap +`</td>
                                                <td></td>
                                                <td>`+ item.ThoiLuong +`</td>
                                                <td>`+ item.LuotXem +`</td>
                                                <td>`+ item.DanhGia +`</td>
                                            </tr>`);
                })
            }
        })
    }
}