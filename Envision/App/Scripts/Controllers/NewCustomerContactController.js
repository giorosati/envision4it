app.controller('NewCustomerContactController', ['$scope', 'NewCustomerContactFactory', '$routeParams', '$q', '$location', function ($scope, NewCustomerContactFactory, $routeParams, $q, $location) {
    $scope.contact = {};
    $scope.newcontact = NewCustomerContactFactory.contact;

    $scope.NewCustomerContact = function () {
        NewCustomerContactFactory.NewCustomerContact($scope.contact, $routeParams.id).then(function (data) {
            $scope.newcontact = data;
            $location.path('/UsersList');
        });
    };
}]);