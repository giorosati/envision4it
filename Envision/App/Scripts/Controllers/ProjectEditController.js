app.controller('ProjectEditController', ['$scope', 'ProjectEditFactory', '$routeParams', '$location', '$q', function ($scope, ProjectEditFactory, $routeParams, $location, $q, defer) {
    //Get the project to pre pop the fiels
    ProjectEditFactory.getProjectbyId($routeParams.id).then(function (data) {
        $scope.project = data;
    });
    $scope.project = {};
    $scope.editProject = ProjectEditFactory.project;
    //editing
    $scope.EditedProject = function () {
        ProjectEditFactory.EditedProject($scope.project, $routeParams.id).then(function (data) {
            $scope.editProject = data;
            $location.path('/AdminHome');
        });
    };
}
]);