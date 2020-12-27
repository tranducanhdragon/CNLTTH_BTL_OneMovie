$(document).ready(function () {

    var btnUpload = $("#upload_file"),
		btnOuter = $(".button_outer");
	//Upload ảnh
	btnUpload.on("change", function (e) {
		$("#uploaded_view").find("img").remove();
		var ext = btnUpload.val().split('.').pop().toLowerCase();
		if($.inArray(ext, ['gif','png','jpg','jpeg']) == -1) {
			$(".error_msg").text("Not an Image...");
		} else {
			$(".error_msg").text("");
			btnOuter.addClass("file_uploading");
			setTimeout(function(){
				btnOuter.addClass("file_uploaded");
			},2000);
			var uploadedFile = URL.createObjectURL(e.target.files[0]);
			setTimeout(function(){
				$("#uploaded_view").append('<img src="'+uploadedFile+'" />');
			},2000);
		}
	});
	//Xóa ảnh
	$(".file_remove").on("click", function(e){
		$("#uploaded_view").find("img").remove();
		$("#uploaded_view").append('<img src="../src/assets/img/film.png" />');
		btnOuter.removeClass("file_uploading");
		btnOuter.removeClass("file_uploaded");
		
	});

	$("#files").shieldUpload();
});