app.controller('UserDetailsController', ['$scope', 'UserDetailsFactory', '$routeParams', '$q', function ($scope, UserDetailsFactory, $routeParams, $q) {
    $scope.UserDetails = UserDetailsFactory.user;
    $scope.profile = {};

    UserDetailsFactory.getUser($routeParams.id).then(function (data) {
        $scope.UserDetails = data;
  
    });
}])