/**
 * Đối tượng JS chứa các hàm sử dụng chung (VD: Format tiền, ngày tháng,...)
 * Author: Bui Trung Tu (12/1/2020)
 * */

var commonJS = {
    formatDate(date) { // định dạng ngày tháng (dd/mm/yyyy)
        try {
            var date = new Date(date);
            var month = date.getMonth() + 1;
            if (month < 10) {
                month = "0" + month;
            }
            var day = date.getDate();
            if (day < 10) {
                day = "0" + day;
            }
            var year = date.getFullYear();
            return day + "/" + month + "/" + year;
        } catch{ }
    },
    getYear(date) {
        try {
            var date = new Date(date);
            var year = date.getFullYear();
            return year;
        } catch{ }
    },
    
}