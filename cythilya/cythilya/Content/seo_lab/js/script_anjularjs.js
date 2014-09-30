function TodoCtrl($scope) {
  $scope.todos = [
    {text:'輕寵食', done:false},
    {text:'果蕊姊妹淘學院', done:false},
    {text:'原味千尋 - 十六倍的堅持，只為一次的感動', done:false},
    {text:'Nike 打出名堂 熱血應援團', done:false},
    {text:'維豐肉鬆-真男人肉乾-來自迪化街老店的維豐肉鬆推出的黑胡椒豬肉紙，鎖住醬汁的厚醇美味', done:false},
    {text:'威航 V Air 台灣第一家廉價航空', done:false},
    {text:'華信航空 微高級俱樂部', done:false},
    {text:'Hello Kitty 40週年，給我抱抱！', done:false},
    {text:'一品禪 - 御選四季食補，全素食手工水餃', done:true},
    {text:'samova 感動3mm', done:true},
    {text:'樂活栽 幸福有機職人', done:false},
    {text:'衛視電影台，影領潮流 閃耀20', done:false},
    {text:'蒙娜麗莎500年：達文西傳奇', done:false},
    {text:'大運99超級任務', done:true}];

  $scope.addTodo = function() {
    $scope.todos.push({text:$scope.todoText, done:false});
    $scope.todoText = '';
  };

  $scope.remaining = function() {
    var count = 0;
    angular.forEach($scope.todos, function(todo) {
      count += todo.done ? 0 : 1;
    });
    return count;
  };

  $scope.archive = function() {
    var oldTodos = $scope.todos;
    $scope.todos = [];
    angular.forEach(oldTodos, function(todo) {
      if (!todo.done) $scope.todos.push(todo);
    });
  };
}