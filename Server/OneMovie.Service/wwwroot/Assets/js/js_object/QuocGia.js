$(document).ready(function () {
    var quocgiajs = new QuocGiaJS();
    quocgiajs.getData();
})

class QuocGiaJS {
    constructor() { };
    getData() {
        $.ajax({
            url: "https://localhost:44305/api/QuocGias",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""
        }).done(function (response) {
            $('#ulQG').empty();
            $.each(response, function (index, item) {
                var liHTML = $(`<li><a >` + item.TenQg + `</a></li>`);
                $('#ulQG').append(liHTML);
            })    
        }).fail(function (response) {

        })
        
    };
}