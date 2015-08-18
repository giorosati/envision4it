app.controller('AdminFAQController', ['$scope', '$location', 'AdminFAQFactory', '$routeParams', '$q', function ($scope, $location, AdminFAQFactory, $routeParams, $q) {
    //getAllFAQs
    AdminFAQFactory.getFAQs($routeParams.id).then(function (data) {
        $scope.FAQs = data;
    });
}]);