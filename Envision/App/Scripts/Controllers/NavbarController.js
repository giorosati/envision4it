app.controller('NavbarController', ['$scope', 'UserFactory', 'SolutionDetailsFactory', function ($scope, UserFactory, SolutionDetailsFactory) {
    $scope.status = UserFactory.status;
    $scope.solutionDetails = SolutionDetailsFactory.solution;
    $scope.isInRole = UserFactory.isInRole;
    $scope.isLoggedIn = UserFactory.isLoggedIn;
    $scope.isLoggedOut = UserFactory.isLoggedOut;

    SolutionDetailsFactory.getSolById().then(function (data) {
        $scope.solutionDetails = data;
    });
    console.log($scope.isLoggedIn());
    console.log($scope.isLoggedOut());
}]);