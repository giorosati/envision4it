app.controller('ProjectController', ['$scope', 'ProjectDetailsFactory', '$routeParams', '$location', '$q', function ($scope, ProjectDetailsFactory, $routeParams, $location, $q) {
    $scope.Project = ProjectDetailsFactory.Project;

    console.log("HELLO");

    ProjectDetailsFactory.GetProject($routeParams.id).then(function (data) {
        $scope.Project = data;
    });

    $scope.DeleteProject = function (id) {
        ProjectDetailsFactory.DeleteProject(id).then(function () {
            $location.path('/AdminHome');
        });
    };
}]);