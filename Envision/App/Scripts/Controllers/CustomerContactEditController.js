app.controller('CustomerContactEditController', ['$scope', 'CustomerContactEditFactory', '$routeParams', '$location', '$q', function ($scope, CustomerContactEditFactory, $routeParams, $location, $q) {
    CustomerContactEditFactory.getCustomerContactbyId($routeParams.id).then(function (data) {
        $scope.contact = data;
    });

    $scope.contact = {};
    $scope.editCustomerContact = CustomerContactEditFactory.contact;

    $scope.EditedCustomerContact = function () {
        CustomerContactEditFactory.EditedCustomerContact($scope.contact, $routeParams.id).then(function (data) {
            console.log("hello")
            $scope.editCustomerContact = data;
            $location.path('/CustomerContacts');
        });
    };
}]);