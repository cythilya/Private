(function($) {
    $.fn.eBook = function(opts) {
        // default configuration
        var config = $.extend({}, {
            speed: 1000,
            start: 0       
        }, opts);
        // main function
        function init(obj) {
            var dObj = $(obj),
                dFrame = dObj.find('.frame'),
                dToggle = dObj.find('.toggle'),
                dCloseBtn = dObj.find('.btnClose'),
                dNav = dObj.find('.nav'),
                dNavLink = dObj.find('.navLink'),
                startOrder = 1,
                imageHeight = dObj.find('.thumbnail').first().height(),
                windowHeight = document.documentElement.clientHeight,
                menuLeft = document.getElementById( 'cbp-spmenu-s1' );

            dObj.find('.item').height(windowHeight);

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