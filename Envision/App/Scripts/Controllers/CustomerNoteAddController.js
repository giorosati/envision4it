app.controller('CustomerNoteAddController', ['$scope', 'CustomerNoteAddFactory', '$routeParams', '$q', '$location', function ($scope, CustomerNoteAddFactory, $routeParams, $q, $location) {
    $scope.customerNote = {};

    $scope.CustomerNoteAdd = function () {
        CustomerNoteAddFactory.customerNoteAdd($scope.customerNote, $routeParams.id).then(function (data) {
            $scope.newNote = data;
            $location.path('/UsersList/');
        });
    };
}]);