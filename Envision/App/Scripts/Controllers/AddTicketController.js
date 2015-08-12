app.controller('AddTicketController', ['$scope', 'AddTicketFactory', '$routeParams', '$q', '$location', function ($scope, AddTicketFactory, $routeParams, $q, $location, defer) {
    $scope.ticket = {};

    $scope.AddTicket = function () {
        AddTicketFactory.addTicket($scope.ticket, $routeParams.id).then(function (data) {
            $scope.newTicket = data;
            $location.path('/Home');
        });
    };
}]);