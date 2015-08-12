app.controller('NewProjectController', ['$scope', 'NewProjectFactory', '$routeParams', '$q', '$location', function ($scope, NewProjectFactory, $routeParams, $q,  $location) {
    $scope.project = {};
    $scope.project.solutions = [];
    $scope.NewProject = function () {
        NewProjectFactory.NewProject($scope.project).then(function (data) {
            $scope.newproject = data;
            
            $location.path('/AdminHome');
        });

    };
    $scope.AddSolution = function () {
        $scope.project.solutions.push({ solutionNotes: [] });
    }
}]);