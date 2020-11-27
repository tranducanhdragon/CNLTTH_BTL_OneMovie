$(document).ready(function () {
    var tl = new TheLoaiJS();
    tl.getData();
})
class TheLoaiJS {
    constructor() { };
    getData() {
        $.ajax({
            url: "https://localhost:44305/api/TheLoais",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""
        }).done(function (response) {
            $('#ulTL').empty();
            $.each(response, function (index, item) {
                var liHTML = $(`<li><a href="genres.html">` + item.TenTl + `</a></li>`);
                $('#ulTL').append(liHTML);
            })
        }).fail(function (response) {

        })
    }
}