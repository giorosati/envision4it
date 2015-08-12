app.controller('EditTicketController', ['$scope', 'EditTicketFactory', '$routeParams', '$location', '$q', function ($scope, EditTicketFactory, $routeParams, $location, $q) {
    //for PrePopulating fields

    EditTicketFactory.getTicket($routeParams.id).then(function (data) {
        //console.log('get ticket is running on the controller');
        $scope.ticket = data;
    });
    $scope.ticket = {};

    //ng-click function calls this fucntion to send it to factory to send to the api
    $scope.SaveEdit = function () {
        EditTicketFactory.EditTicket($scope.ticket, $routeParams.id).then(function (data) {
            $scope.editTicket = data;
            $location.path('/AdminHome');
        });
    };
}]);