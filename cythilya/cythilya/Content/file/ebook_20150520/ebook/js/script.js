(function($) {
    $.fn.eBook = function(opts) {
        // default configuration
        var config = $.extend({}, {
            speed: 1000,
            start: 0       
        }, opts);
        // main function
        function init(obj) {
            var dObj = $(obj);
            var dFrame = dObj.find('.frame');
            var dNav = dObj.find('.nav');
            var dNavLink = dObj.find('.navLink');
            var dToggle = dObj.find('.toggle');
            var dCloseBtn = dObj.find('.btnClose');
            var dSlide = dObj.find('.swipe');
            var startOrder = 1;

            //頁面滑動
            dNavLink.click(function(e){
                var nowOrder = $(this).data('order');
                var length = -(nowOrder - startOrder)*1024;
                e.preventDefault();
                dFrame.animate({top: length + 'px'}, config.speed); 
            });

            //選單開關
            dToggle.click(function(e){
                e.preventDefault();
                if(!dNav.hasClass('on')){
                    dNav.addClass('on');
                }
                else{
                    dNav.removeClass('on');
                }
            });

            //關閉選單
            dCloseBtn.click(function(e){
                e.preventDefault();
                if(!dNav.hasClass('on')){
                    dNav.addClass('on');
                }
                else{
                    dNav.removeClass('on');
                }
            });
            
            dSlide.slick({
                dots: true,
                adaptiveHeight: true,
                arrows: false,
                mobileFirst: true,
                slidesToShow: 3,
                slidesToScroll: 3           
            });
            //dSlide.css('height', '200px');


        }
        // initialize every element
        this.each(function() {
            init($(this));
        });
        return this;
    };
    // start
    $(function() {
        $('.ebook').eBook();
    });
})(jQuery);