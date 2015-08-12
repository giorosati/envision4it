app.controller('CustController', ['$scope', 'UserFactory', 'SolutionDetailsFactory', function ($scope, UserFactory, SolutionDetailsFactory) {
    $scope.status = UserFactory.status;
    $scope.solutionDetails = SolutionDetailsFactory.solution;

    SolutionDetailsFactory.getSolById().then(function (data) {
        $scope.solutionDetails = data;
    });
}]);