$(document).ready(function () {

})
class PhanPhimJS {
    constructor() { };
    getData() {
        $.ajax({
            url: "/PhanPhimsController/GetPhanPhims",
            method: "GET",
            data: "",
            contentType: "application/json",
            dataType: ""

        }).done(function (response) {

        }).fail(function () {

        })
    };
}