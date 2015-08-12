app.controller('SolutionDetailsController', ['$scope', 'SolutionDetailsFactory', '$routeParams', '$location', '$q', function ($scope, SolutionDetailsFactory, $routeParams, $location, $q) {

    $scope.solutionDetails = SolutionDetailsFactory.solution;

    SolutionDetailsFactory.getSolution($routeParams.id).then(function (data) {
        $scope.solutionDetails = data;
    });
    $scope.DeleteTicket = function (id) {
        SolutionDetailsFactory.DeleteTicket(id);
    }
    $scope.TicketDetails = function (id) {
        $location.path('/TicketEdit/' + id);
    };

    $scope.DeleteHardware = function (hardwareid) {
        SolutionDetailsFactory.DeleteHardware(hardwareid, $routeParams.id);
    };
    $scope.DeleteFaq = function (id) {
        SolutionDetailsFactory.DeleteHardware(faq, hardware);
    };
}]);