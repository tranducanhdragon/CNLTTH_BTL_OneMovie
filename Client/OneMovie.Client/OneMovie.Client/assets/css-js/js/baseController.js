var common = {
    init: function () {
        common.TenBoPhim();
        common.MaPhimBo();
        common.TenDaoDien();
        common.MaQuocGia();
        common.MaTheLoai();
        common.MaNhaXuatBan();
    },
    TenBoPhim: function () {
        $("#txtTenBoPhim").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/AdminHome/ListTenBP",
                    dataType: "json",
                    data: {
                        bp: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            //focus: function (event, ui) {
            //    $("#txtTenBoPhim").val(ui.item.label);
            //    return false;
            //},
            select: function (event, ui) {
                $("#txtTenBoPhim").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>").append("<a>" + item.label + "</a>").appendTo(ul);
        };
    },
    MaPhimBo: function () {
        $("#txtMaPhimBo").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/AdminHome/ListMaPB",
                    dataType: "json",
                    data: {
                        mpb: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            //focus: function (event, ui) {
            //    $("#txtTenBoPhim").val(ui.item.label);
            //    return false;
            //},
            select: function (event, ui) {
                $("#txtMaPhimBo").val(ui.item.PhimBo);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>").append("<a>" + item.PhimBo + "." + item.TenBP+ "</a>").appendTo(ul);
        };
    },
    TenDaoDien: function() {
        $("#txtTenDaoDien").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/AdminHome/ListTenDD",
                    dataType: "json",
                    data: {
                        dd: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            //focus: function (event, ui) {
            //    $("#txtTenDaoDien").val(ui.item.label);
            //    return false;
            //},
            select: function (event, ui) {
                $("#txtTenDaoDien").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>").append("<a>" + item.label + "</a>").appendTo(ul);
        };
    },
    MaQuocGia: function() {
        $("#txtMaQuocGia").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/AdminHome/ListMaQG",
                    dataType: "json",
                    data: {
                        mqg: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            //focus: function (event, ui) {
            //    $("#txtMaQuocGia").val(ui.item.MaQG);
            //    return false;
            //},
            select: function (event, ui) {
                $("#txtMaQuocGia").val(ui.item.MaQG);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>").append("<a>" + item.MaQG+'. '+item.TenQG + "</a>").appendTo(ul);
        };
    },
    MaTheLoai: function() {
        $("#txtMaTheLoai").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/AdminHome/ListMaTL",
                    dataType: "json",
                    data: {
                        mtl: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            //focus: function (event, ui) {
            //    $("#txtMaTheLoai").val(ui.item.MaTL);
            //    return false;
            //},
            select: function (event, ui) {
                $("#txtMaTheLoai").val(ui.item.MaTL);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>").append("<a>" + item.MaTL+'. '+item.TenTL + "</a>").appendTo(ul);
        };
    },
    MaNhaXuatBan: function() {
        $("#txtMaNSX").autocomplete({
            minLength: 0,
            source: function (request, response) {
                $.ajax({
                    url: "/AdminHome/ListMaNSX",
                    dataType: "json",
                    data: {
                        mnsx: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            //focus: function (event, ui) {
            //    $("#txtMaNSX").val(ui.item.MaNSX);
            //    return false;
            //},
            select: function (event, ui) {
                $("#txtMaNSX").val(ui.item.MaNSX);
                return false;
            }
        }).autocomplete("instance")._renderItem = function (ul, item) {
            return $("<li>").append("<a>" + item.MaNSX+'. '+item.TenNSX + "</a>").appendTo(ul);
        };
    }
}
common.init();