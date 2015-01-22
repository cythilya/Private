/*!
 * jQuery plugin
 * What does it do
 */
(function($) {
	$.fn.pluginName = function(opts) {
		// default configuration
		var config = $.extend({}, {
			opt1: null
		}, opts);
		// main function
		function init(obj) {
            obj.addClass('aaa');
        }
		// initialize every element
		this.each(function() {
			init($(this));
		});
		return this;
	};
	// start
	$(function() {
		$("#bbb").pluginName();
	});
})(jQuery);
