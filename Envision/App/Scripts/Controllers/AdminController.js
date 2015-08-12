app.controller('AdminController', ['$scope', 'AdminFactory', '$location', function ($scope, AdminFactory, $location) {

    $scope.Projects = AdminFactory.Projects;

    $scope.toggleSolution = function (id) {
        if (id != null)
        { return false }
        else { return true }
    };

    $scope.toggleTicket = function (id) {
        if (id != null)
        { return false }
        else { return true }
    };

    $scope.DeleteProject = function (id) {
        AdminFactory.DeleteProject(id);
    };

    $scope.DeleteSolution = function (solution, project) {
        AdminFactory.DeleteSolution(solution, project);
    };
}]);