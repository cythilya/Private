/*
var todos = [
	{ id: 0, name: "Buy milk", status: 0 },
	{ id: 1, name: "History group at 10", status: 1 },
    { id: 2, name: "Need new parking sticker", status: 0 },
	{ id: 3, name: "Answer dad's email'", status: 0 },
	{ id: 4, name: "Call Peter", status: 0 },
	{ id: 5, name: "ATM cash", status: 0 },
	{ id: 6, name: "Call Patty after work", status: 0 }
]; 
var count = todos.length+1;
*/

//list all items
exports.index = function(req, res){
	var todos = todos;
	//console.log(res.body);
	res.render( 'index', {
		title : 'To-Do List',
		todos : todos
	});	
};

//create item
exports.create = function(req, res){
	var element = { id: count++, name: req.body.newItem, status: 0 };
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





