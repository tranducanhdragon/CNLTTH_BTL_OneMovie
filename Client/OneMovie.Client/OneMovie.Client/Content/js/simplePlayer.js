
(function( $ ) {
	$.fn.simplePlayer = function() {
		var	video = $(this);
		var play = $('<div />', { id: 'play' }).hide();
		play.appendTo( video ).fadeIn('slow');
		play.bind('click', function () { 
			if ( !$('#player').length ) {
				$('<iframe />', {
					id: 'player',
					src: 'https://drive.google.com/file/d/' + video.data('video') + '/preview',
					allowfullscreen:'allowfullscreen'
				})
				.attr({ width: video.width(), height: video.height()})
				.css('border', 'none')
				.appendTo(video); 
				video.children('img').hide();
			}
			$(this).hide();
		});
	};
}( jQuery ));