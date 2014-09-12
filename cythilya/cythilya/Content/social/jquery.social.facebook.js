var SocialFb = {};
SocialFb.module = {
    version: '0.1',
    nameSocialFbace: function(ns_string){
        var parts = ns_string.SocialFblit('.'),
            parent = SocialFb,
            i;
        if (parts[0] === 'SocialFb'){
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
    pageIndex: function(dModule){
		var dModule = $(dModule);
    }
};
(function(){
    var doWhileExist = function(ModuleID,objFunction){
        var dTarget = document.getElementById(ModuleID);
        if(dTarget){
            objFunction(dTarget);
        }                
    };
    doWhileExist('pageIndex',SocialFb.module.pageIndex);
})();