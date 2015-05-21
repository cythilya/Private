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
                dSlide = dObj.find('.swipe'),
                dNav = dObj.find('.nav'),
                dMenuHeading = document.getElementById( 'menuHeading' ),
                dNavLink = dObj.find('.navLink')
                dAd =  dObj.find('.adArea'),
                dMask = dObj.find('.mask'),
                selScrollable = '.scrollable',
                imageHeight = dObj.find('.thumbnail').first().height(),
                windowHeight = document.documentElement.clientHeight,
                menuLeft = document.getElementById( 'cbp-spmenu-s1' ),
                startOrder = 1,
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
                classie.toggle( menuHeading, 'on' );
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

            function init(){
                dObj.find('iframe').width($(window).innerWidth());
                dObj.find('.swipe').width($(window).innerWidth());
                dObj.find('.item').height(windowHeight);
                //dObj.find('.navList').height(windowHeight);
                dObj.find('.dropdown .navList').css('height', 400 + 'px');
                dObj.find('.dropdown .navList').css('max-height', 400 + 'px');
                adMaxHeight = windowHeight-imageHeight;
                dObj.find('.adList').slick({
                    dots: false,
                    adaptiveHeight: true,
                    arrows: false,
                    mobileFirst: true,
                    slidesToShow: 1,
                    slidesToScroll: 1,
                    infinite: true,
                    swipe: true,
                    autoplay: true,
                    lazyLoad: 'progressive'          
                });
                dAd.css('max-height', adMaxHeight + 'px');
                dAd.find('.adImg').css('max-height', adMaxHeight-20  + 'px');  
                if(adMaxHeight > config.adShowLimit){
                    dAd.show()
                } 
                else {
                    dAd.hide();
                }                  

                dSlide.slick({
                    dots: true,
                    adaptiveHeight: true,
                    arrows: false,
                    mobileFirst: true,
                    slidesToShow: 3,
                    slidesToScroll: 3
                });  
                dSlide.show();       
                $(window).scrollTop(0); 
            }

            //touch event init
            function touchInit(){
                /*
                $('.container').on('touchmove touchstart touchend touchcancel',function(e){
                    if(e.type == 'touchmove'){
                        alert('touchmove');
                    }
                    if(e.type == 'touchstart'){
                        alert('touchstart');
                    }
                    if(e.type == 'touchend'){
                        alert('touchend');
                    }
                    if(e.type == 'touchcancel'){
                        alert('touchcancel');
                    }                                                            
                });
                */

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

            //init
            $(document).ready(function() {
                $(window).resize(function(){
                    init();
                    touchInit();
                    if($(window).innerWidth()>$(window).innerHeight()){
                        //橫
                       //dMask.show();
                       dMask.hide(); 
                    }else{
                        //直
                        dMask.hide();
                    } 
                 }).resize();
            });    

            $('.navList').on('touchmove', function (e) {
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