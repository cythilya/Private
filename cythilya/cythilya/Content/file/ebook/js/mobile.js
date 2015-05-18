(function($) {
    $.fn.eBook = function(opts) {
        // default configuration
        var config = $.extend({}, {
            speed: 1000,
            start: 0,
            adShowLimit: 50    
        }, opts);
        // main function
        function init(obj) {
            var dObj = $(obj),
                dFrame = dObj.find('.frame'),
                dToggle = dObj.find('.toggle'),
                dCloseBtn = dObj.find('.btnClose'),
                dNav = dObj.find('.nav'),
                dNavLink = dObj.find('.navLink')
                dAd =  dObj.find('.adArea'),
                selScrollable = '.scrollable',
                startOrder = 1,
                imageHeight = dObj.find('.thumbnail').first().height(),
                windowHeight = document.documentElement.clientHeight,
                menuLeft = document.getElementById( 'cbp-spmenu-s1' ),
                adMaxHeight = 0;

            dNavLink.click(function(e){
                var nowOrder = $(this).data('order');
                var length = -(nowOrder - startOrder)*windowHeight;
                e.preventDefault();
                dFrame.animate({top: length + 'px'}, config.speed); 
            });

            dToggle.click(function(e){
                e.preventDefault();
                classie.toggle( this, 'active' );
                classie.toggle( menuLeft, 'cbp-spmenu-open' );
                disableOther( 'showLeft' );
            });

            dCloseBtn.click(function(e){
                e.preventDefault();
                classie.toggle( this, 'active' );
                classie.toggle( menuLeft, 'cbp-spmenu-open' );
                disableOther( 'showLeft' );
            });

            function disableOther( button ) {
                if( button !== 'showLeft' ) {
                    classie.toggle( showLeft, 'disabled' );
                }
            }

            //init
            dObj.find('.item').height(windowHeight);
            adMaxHeight = windowHeight-imageHeight;
            if(adMaxHeight > config.adShowLimit){
                dAd.css('max-height', adMaxHeight + 'px');
                dAd.find('.adImg').css('max-height', adMaxHeight-20  + 'px');
                dObj.find('.adList').slick({
                    dots: false,
                    adaptiveHeight: true,
                    arrows: false,
                    mobileFirst: true,
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    swipe: false,
                    autoplay: true,
                    lazyLoad: 'progressive'          
                });
            } else {
                dAd.hide();
            }

            //touch event init
            $(document).on('touchmove',function(e){
                e.preventDefault();
            });

            $('body').on('touchstart', selScrollable, function(e) {
                if (e.currentTarget.scrollTop === 0) {
                    e.currentTarget.scrollTop = 1;
                } else if (e.currentTarget.scrollHeight === e.currentTarget.scrollTop + e.currentTarget.offsetHeight) {
                    e.currentTarget.scrollTop -= 1;
                }
            });

            $('body').on('touchmove', selScrollable, function(e) {
                e.stopPropagation();
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
        $('.ebookMobile').eBook();
    });
})(jQuery);