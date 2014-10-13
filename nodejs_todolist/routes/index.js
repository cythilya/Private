/*
 * GET home page.
 */
var count = 1;
var todos = [
	{ id: 0, name: "果蕊姊妹淘學院", status: 0 },
	{ id: 1, name: "Nike 打出名堂 熱血應援團", status: 1 }
]; 

//list all items
exports.index = function(req, res){
	res.render( 'index', {
		title : 'To-Do List',
		todos : todos
	});	
};

//create item
exports.create = function(req, res){
	var element = { id: count++, name: req.body.newItem };
	todos.push(element);
	return res.redirect('/');
};

//remove item
exports.remove = function(req, res){
	var id = req.params.id;
	var newArray = [];
	
	for (var i = 0; i < todos.length; i++) { 
		if(todos[i].id != id){
			newArray.push(todos[i]);
		}
	}
	
	todos = [];
	todos = newArray;
	return res.redirect('/');
};

exports.edit = function(req, res){
	var id = req.params.id;
	for (var i = 0; i < todos.length; i++) { 
		if(todos[i].id == id){
			todos[i].name = req.body.editItem;
		}
	}
	return res.redirect('/');
};





