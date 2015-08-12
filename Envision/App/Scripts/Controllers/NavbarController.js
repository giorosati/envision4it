app.controller('NavbarController', ['$scope', 'UserFactory', 'SolutionDetailsFactory', function ($scope, UserFactory, SolutionDetailsFactory) {
    $scope.status = UserFactory.status;
    $scope.solutionDetails = SolutionDetailsFactory.solution;
    $scope.isInRole = UserFactory.isInRole;

    SolutionDetailsFactory.getSolById().then(function (data) {
        $scope.solutionDetails = data;
    });
}]);