app.controller('UserController', ['$scope', 'UserFactory', '$location', function ($scope, UserFactory, $location) {
    $scope.user = {};

    $scope.login = function (user) {
        UserFactory.login(user).then(function (roles) {
            //success then
            if (roles.indexOf('Admin') !== -1 || roles.indexOf('Root') !== -1) {
                $location.path('/AdminHome');
            }
            else if (roles.indexOf('Tech') !== -1) {
                $location.path('/t');
            }
            else if (roles.indexOf('User') !== -1) {
                $location.path('/c');
            }
            else
            {
                $location.path('/');
            }
        }, function (data) {
            //fail then
            $scope.message = data;
        });
    };
}]);