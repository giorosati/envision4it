app.controller('RegistrationController', ['$scope', 'UserDetailsFactory', '$routeParams', '$q', '$location', function ($scope, UserDetailsFactory, $routeParams, $q, $location) {
    $scope.register = function (){
        UserDetailsFactory.register($scope.user).then(function (data) {
            $scope.user = data;
            $location.path("/Home");
        
        });
    };
}])