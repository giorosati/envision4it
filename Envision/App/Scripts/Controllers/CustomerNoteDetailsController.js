app.controller('CustomerNoteDetailsController', ['$scope', 'CustomerNoteDetailsFactory', '$routeParams', '$q', function ($scope, CustomerNoteDetailsFactory, $routeParams, $q) {
    $scope.CustomerNoteDetails = CustomerNoteDetailsFactory.note;
    CustomerNoteDetailsFactory.getNote($routeParams.id).then(function (data) {
        $scope.CustomerNoteDetails = data;
    });
}])