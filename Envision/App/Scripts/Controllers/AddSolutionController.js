app.controller('AddSolutionController', ['$scope', 'AddSolutionFactory', '$routeParams', '$q', '$location', function ($scope, AddSolutionFactory, $routeParams, $q, $location) {
    $scope.solution = {};
   
    $scope.AddSolution = function () {
        AddSolutionFactory.AddSolution($routeParams.id, $scope.solution).then(function (data) {
            $scope.newSolution = data;
            
                $location.path("/SolutionDetails/" + data.ProjectID);


        });
    };
}]);