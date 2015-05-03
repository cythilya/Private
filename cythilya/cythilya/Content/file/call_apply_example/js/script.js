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
    playground: function(dModule){

        function Project(id, title, owner_id) {
            this.id = id;
            this.title = title;
            this.owner_id = owner_id;
        };

        Project.prototype.get_owner = function(callback) {
            var self = this;

            $.ajax.fake.registerWebservice('/owners/' + this.owner_id, function(data) {
                return {
                    "owner": "Jimmy"
                }
            });

            $.ajax({
                type:'GET',
                dataType:'json',
                fake: true,
                url:'/owners/' + this.owner_id,
                error: function(){
                    console.log('Error!');
                },
                success:function(data) {
                    callback && callback.call(self, data.owner);
                }
            });      
        };

        var proj = new Project(999, 'proj_1', 2);
        proj.get_owner(function(owner) {
            console.log('The project ' + this.title + ' belongs to ' + owner);
            alert('The project ' + this.title + ' belongs to ' + owner);
        });
    }
};
(function(){
    var doWhileExist = function(ModuleID,objFunction){
        var dTarget = document.getElementById(ModuleID);
        if(dTarget){
            objFunction(dTarget);
        }                
    };
    doWhileExist('playground',SP.module.playground);
})();