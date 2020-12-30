$(document).ready(function () {


	$("#btn-saveMovie").on('click', () => {
		let obj = {};
		let fields = $(".model-body input");
		$.each(fields, function (index, field) {
			var fieldName = $(field).attr('fieldname');
			obj[fieldName] = $(field).val();
		})
		console.log(obj);
	})

	$("#btn-save-movie").on('click', () => {
		let obj = {};
		let fields = $(".form-row input");
		$.each(fields, function (index, field) {
			var fieldName = $(field).attr('fieldname');
			obj[fieldName] = $(field).val();
		})
		console.log(obj);
    })

	//Upload video
	$("#video_film").on("change", (e) => {
		let formData = new FormData();
		formData.append("files", e.target.files[0]);
		$.ajax({
			url: '/api/PhanPhims/VideoFilm',
			data: formData,
			method: "POST",
			processData: false,
			contentType: false,
		}).done((res) => {
			console.log(res);
		}).fail((err) => {
			console.log(err);
		})
    })


	//Upload ảnh
	$("#upload_file").on("change", function (e) {
		$("#uploaded_view").find("img").remove();
		var ext = btnUpload.val().split('.').pop().toLowerCase();
		if($.inArray(ext, ['gif','png','jpg','jpeg']) == -1) {
			$(".error_msg").text("Not an Image...");
		} else {
			$(".error_msg").text("");
			$(".button_outer").addClass("file_uploading");
			setTimeout(function(){
				$(".button_outer").addClass("file_uploaded");
			},2000);
			var uploadedFile = URL.createObjectURL(e.target.files[0]);
			setTimeout(function(){
				$("#uploaded_view").append('<img src="'+uploadedFile+'" />');
			}, 2000);

			let formData = new FormData();
			let obj = {};
			obj.TenPhim = 'Test 1 chút';
			formData.append("files", e.target.files[0]);
			$.ajax({
				url: '/api/PhanPhims/VideoFilm',
				data: formData,
				method: "POST",
				processData: false,
				contentType: false,
			}).done((res) => {
				console.log(res);
			}).fail((err) => {
				console.log(err);
			})
		}
	});
	//Xóa ảnh
	$(".file_remove").on("click", function(e){
		$("#uploaded_view").find("img").remove();
		$("#uploaded_view").append('<img src="../src/assets/img/film.png" />');
		$(".button_outer").removeClass("file_uploading");
		$(".button_outer").removeClass("file_uploaded");
	});

	//$("#files").shieldUpload();
});
