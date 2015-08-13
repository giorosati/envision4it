app.controller('AdminTicketController', ['$scope', '$location', 'AdminTicketFactory', '$routeParams', '$q', function ($scope, $location, AdminTicketFactory, $routeParams, $q) {

    //getAllTickets
    AdminTicketFactory.getTickets($routeParams.id).then(function(data){
        $scope.tickets = data;
    });
}]);