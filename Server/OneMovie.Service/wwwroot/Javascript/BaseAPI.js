var BaseAPI = {
    /**
     * @param {string} url // link tới service (VD: https://localhost:44305/api/PhanPhims)
     * @param {string} id // khóa chính của đối tượng trong csdl
    */

    Get(url) {
        try {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: url,
                    method: "GET",
                    contentType: "application/json",
                    dataType: "json",
                    async: false
                }).done((res) => {
                    resolve(res)
                }).fail((err) => {
                    reject(err)
                })
            })
        } catch{
            console.log('Không thể kết nối tới server')
        }
    },

    GetByID(url,id) {
        try {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: url + '/' + id,
                    method: "GET",
                    contentType: "application/json",
                    dataType: "json",
                    async: false
                }).done((res) => {
                    resolve(res);
                }).fail((err) => {
                    reject(err);
                })
            })
            
        } catch{
            console.log('Không thể kết nối tới server')
        }
    },

    Post(url,obj) {
        try {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: url,
                    method: "POST",
                    data: JSON.stringify(obj),
                    contentType: "application/json",
                    dataType: "json",
                    async: false
                }).done((res) => {
                    resolve(res)
                }).fail((err) => {
                    reject(err);
                })
            })
            
        } catch{
            console.log('Không thể kết nối tới server')
        }
    },

    PUT(url,obj) {
        try {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: url,
                    method: "PUT",
                    data: JSON.stringify(obj),
                    contentType: "application/json",
                    dataType: "json",
                    async: false
                }).done((res) => {
                    resolve(res)
                }).fail((err) => {
                    reject(err);
                })
            })
        } catch{
            console.log('Không thể kết nối tới server')
        }
    },

    DELETE(url, id) {
        try {
            return new Promise((resolve, reject) => {
                $.ajax({
                    url: url + '/' + id,
                    method: "DELETE",
                    async: false
                }).done((res) => {
                    resolve(res)
                }).fail((err) => {
                    reject(err);
                })
            })
          
        } catch{
            console.log('Không thể kết nối tới server')
        } 
    }

}