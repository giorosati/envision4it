app.controller('SolutiontEditController', ['$scope', 'SolutionEditFactory', '$routeParams', '$location', '$q', function ($scope, SolutionEditFactory, $routeParams, $location, $q, defer) {
    SolutionEditFactory.getSolutionbyId($routeParams.id).then(function (data) {
        $scope.solution = data;
    });
    $scope.solution = {};
    $scope.editSolution = SolutionEditFactory.solution;

    $scope.EditedSolution = function () {
        SolutionEditFactory.EditedSolution($scope.solution, $routeParams.id).then(function (data) {
            $scope.editSolution = data;
            $location.path('/AdminHome');
        });
    };
}]);