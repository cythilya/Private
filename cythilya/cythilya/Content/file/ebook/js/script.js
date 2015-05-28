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
            var dMainContent = dObj.find('.mainContent');
            var dFrame = dObj.find('.frame');
            var dNav = dObj.find('.nav');
            var dNavLink = dObj.find('.navLink');
            var dToggle = dObj.find('.toggle');
            var dCloseBtn = dObj.find('.btnClose');
            var dSlide = dObj.find('.swipe');
            var dItem = dObj.find('.item'); 
            var startOrder = 1;

            //頁面滑動
            dNavLink.click(function(e){
                var nowOrder = $(this).data('order');
                var length = -(nowOrder - startOrder)*680;
                var dThisLink = $(this);
                e.preventDefault();
                dFrame.animate({top: length + 'px'}, config.speed); 
                dObj.find('.navLink').removeClass('active');
                dThisLink.addClass('active');
            });

            dMainContent.click(function(e){
                if(!dNav.hasClass('on')){
                    dNav.addClass('on');
                }
                else{
                    dNav.removeClass('on');
                }
            });            

            $(document).click(function(e){
                var dThisNav = dObj.find('.nav');
                e.stopPropagation();
                if(!dObj.has(e.target).length) {
                    if(dThisNav.hasClass('on')){
                        dThisNav.removeClass('on');
                    }
                }
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

            //init
            dItem.find('.inner').css('max-height', document.documentElement.clientHeight + 'px');
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