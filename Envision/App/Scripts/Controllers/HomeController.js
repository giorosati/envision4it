app.controller('HomeController', ['$scope', 'AdminFactory', function ($scope, AdminFactory) {
    $scope.Projects = AdminFactory.Projects;
    $scope.Solutions = AdminFactory.Solutions;
    $scope.Tickets = AdminFactory.Tickets;
}]);