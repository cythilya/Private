CKEDITOR.plugins.add( 'simpleimageupload', {
    icons: 'simpleimageupload',
    init: function( editor ) {
		editor.ui.addButton( 'Simpleimageupload', {
            label: 'Simple Image Upload',
            command: 'simpleimageupload',
            toolbar: 'insert'
        });
		
		editor.on('click', function( event ) {
			/*
			var dThisBtn = $(this);
			dThisBtn.click(function(){}
				alert('ed');
			});
			alert( event.data );
			// 'Example'
			*/
			console.log($(this));
		} );	
		
		editor.fire( 'click', 'Example' );
    }
});
