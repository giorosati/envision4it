app.controller('CustomerContactDetailsController', ['$scope', 'CustomerContactDetailsFactory', '$routeParams', '$q', function ($scope, CustomerContactDetailsFactory, $routeParams, $q) {
    $scope.CustomerContactDetails = CustomerContactDetailsFactory.contact;

    CustomerContactDetailsFactory.getContact($routeParams.id).then(function (data) {
        $scope.CustomerContactDetails = data;
    });
}]);