app.controller('ProjectDetailsController', ['$scope', 'ProjectDetailsFactory', '$routeParams', '$location', '$q', function ($scope, ProjectDetailsFactory, $routeParams, $location, $q) {

    $scope.Project = ProjectDetailsFactory.Project;
    $scope.Projects = ProjectDetailsFactory.Projects;

    console.log("HELLO");

    //$scope.GetProject = function (id) {
    //    ProjectDetailsFactory.GetProject($routeParams.id).then(function (data) {
    //    $scope.project = data;
    //}
    //);


    //ProjectDetailsFactory.getAllProjects().then(function (data) {
    //    $scope.project = data;
    //});

    $scope.DeleteProject = function (id) {
        ProjectDetailsFactory.DeleteProject(id).then(function () {
            $location.path('/AdminHome');
        });
    };
}]);