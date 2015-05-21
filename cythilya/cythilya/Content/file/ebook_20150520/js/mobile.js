(function($) {
	$.fn.ebookMobile = function(opts) {
		// default configuration
		var config = $.extend({}, {
			menuOPushSpeed: 500,
			pageSlideSpeed: 1000,
			adShowLimitHeight: 50
		}, opts);
		// main function
		function init(obj) {
			var dObj = $(obj),
				dToggle = dObj.find('.toggle'),
				dMenu = dObj.find('.menu'),
				dNavList = dMenu.find('.navList'),
				dContainer = dObj.find('.container'),
				dPageList = dObj.find('.pageList'),
				dPageItem = dObj.find('.pageItem'),
				dSlide = dObj.find('.swipe'),
				dAd =  dObj.find('.adArea'),
				dAdList = dObj.find('.adList'),
				dMask = dObj.find('.mask'),
				windowWidth = $(window).innerWidth(),
				windowHeight = document.documentElement.clientHeight,
				menuPushDistance = windowWidth * 0.4,
				adMaxHeight = 0;

			dToggle.click(function(e){
				var dThisToggle = $(this);
				e.preventDefault();
				if(!dThisToggle.hasClass('on')){
					dThisToggle.addClass('on');
					dMenu.stop().animate({'left': '0'}, config.menuOPushSpeed);
				}
				else{
					dMenu.stop().animate({'left': '-' + menuPushDistance}, config.menuOPushSpeed, function(){
						dThisToggle.removeClass('on');
					});
				}
			});

			dNavList.on('click', '.navLink', function(e){
				var dThisLink = $(this);
				var num = dThisLink.index() || 0;
				var pos = $('.container .pageItem').eq(num).position().top;
				e.preventDefault();
				dPageList.stop().animate({'top': -pos}, config.pageSlideSpeed);
			});

            dAdList.slick({
                dots: false,
                adaptiveHeight: true,
                arrows: false,
                mobileFirst: true,
                slidesToShow: 1,
                slidesToScroll: 1,
                infinite: true,
                swipe: true,
                autoplay: true
            });

            dSlide.slick({
                dots: true,
                adaptiveHeight: true,
                arrows: false,
                mobileFirst: true,
                slidesToShow: 3,
                slidesToScroll: 3
            });			
			
			function init(){
				dObj.find('.thumbnail').width($(window).innerWidth());
				adMaxHeight = $(window).innerHeight() - 4/3*$(window).innerWidth(); //1024/768=4/3
				dAd.css('max-height', adMaxHeight + 'px');
	            dAd.find('.adImg').css('max-height', adMaxHeight-20  + 'px');
	            if(adMaxHeight > config.adShowLimitHeight){
	                dAd.show()
	            } 
	            else {
	                dAd.hide();
	            }
	            dSlide.show();	 
			}

			//init
			init();
			
            $(window).resize(function(){
            	init();
                if($(window).innerWidth()>$(window).innerHeight()){
                	dMask.show(); //橫
                } else {
                    dMask.hide(); //直
                } 
             }).resize();
        }
		// initialize every element
		this.each(function() {
			init($(this));
		});
		return this;
	};
	// start
	$(function() {
		$('.ebookMobile').ebookMobile();
	});
})(jQuery);