(function($) {
	$.fn.overlayMenu = function(opts) {
		// default configuration
		var config = $.extend({}, {
			menuOPushSpeed: 200,
			adShowLimitHeight: 50,
			menuPushDistance: 180
		}, opts);
		// main function
		function init(obj) {
			var dObj = $(obj),
				dHTML = $('html'),
				dBody = $('body'),
				dToggle = dObj.find('.toggle'),
				dMenu = dObj.find('.menu'),
				dPageContainer = dObj.find('.pageContainer'),
				windowWidth = $(window).innerWidth(),
				menuPushDistance = config.menuPushDistance;

			function lockScreen(){
				dHTML.addClass('lock');
				dBody.addClass('lock');
			};

			function unlockScreen(){
				dHTML.removeClass('lock');
				dBody.removeClass('lock');		
			};

            function openMenu(){
				dToggle.addClass('on');
				dMenu.stop().animate({'left': '0'}, config.menuOPushSpeed);
				lockScreen();
            };	

            function closeMenu(){
				dMenu.stop().animate({'left': '-' + menuPushDistance}, config.menuOPushSpeed, function(){
					dToggle.removeClass('on');
					unlockScreen();
				}); 
            };

			dToggle.click(function(e){
				e.preventDefault();
				if(!dToggle.hasClass('on')){
					openMenu();
				}
				else{
					closeMenu();
				}
			});

			dPageContainer.click(function(e){
				if(dToggle.hasClass('on')){
					closeMenu();
				}
			});
        }
		// initialize every element
		this.each(function() {
			init($(this));
		});
		return this;
	};
	// start
	$(function() {
		$('.EventPalMobile').overlayMenu();
	});
})(jQuery);