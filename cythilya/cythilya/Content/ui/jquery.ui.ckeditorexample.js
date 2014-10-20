var SP = {};
SP.module = {
    version: '0.1',
    namespace: function(ns_string){
        var parts = ns_string.split('.'),
            parent = SP,
            i;
        if (parts[0] === 'SP'){
            parts = parts.slice(1);
        }
        for (i = 0; i < parts.length; i += 1){
            if (typeof parent[parts[i]] === 'undefined') {
                parent[parts[i]] = {};
            }
            parent = parent[parts[i]];
        }
        return parent;
    },
    inherit: function(Child, Parent){
        Child.prototype = new Parent();
    },
    ckeditorArea: function(dModule){
		var dModule = $(dModule);
		var editorTextarea = dModule.find('#editorTextarea');
		var btnSave = dModule.find('.btnSave');
		CKEDITOR.replace('editorTextarea');
		
		//get initial data
		var out = localStorage.getItem('editorSnippet');
		if(out != null){
			editorTextarea.html(decodeURIComponent(out));
		}
		else{
			console.log('Nothing to display.');
		}
		
		//save data
		btnSave.click(function(){
			var editor_data = CKEDITOR.instances.editorTextarea.getData();
			dModule.find('#editorTextarea').val(encodeURIComponent(editor_data));
			localStorage.setItem('editorSnippet', encodeURIComponent(editor_data));	
			alert('Success!');
			location.reload();
				
			/*
			$.ajax({
				url: '/UI/UI/SaveEditorContent',
				type: 'post',
				data: {
					htmlSnippet: encodeURIComponent(editor_data)
				},
				dataType: 'json',
				error: function (xhr) {},
				success: function (response) {
					if(response.IsSuccess){
						alert('Success!');
						location.reload();
					}
					else{
						alert('Error!');
					}
				}
			})
			*/
		});
    },	
    out: function(dModule){
        var dModule = $(dModule);
		var out = localStorage.getItem('editorSnippet');
		
		if(out != null){
			dModule.html(decodeURIComponent(out));
		}
		else{
			console.log('Nothing to display.');
		}
    }
};
(function(){
    var doWhileExist = function(ModuleID,objFunction){
        var dTarget = document.getElementById(ModuleID);
        if(dTarget){
            objFunction(dTarget);
        }
    };
    doWhileExist('ckeditorArea',SP.module.ckeditorArea);
    doWhileExist('out',SP.module.out);
})();