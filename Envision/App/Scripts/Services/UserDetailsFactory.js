app.factory('UserDetailsFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.user = {};

    o.register = function (user) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('/api/Account/Register/', user, config).success(function (data) {
            defer.resolve(data)
        });
        return defer.promise;
    };

    o.getUser = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiUserDetails/', config).success(function (data) {
            o.user = data;
            defer.resolve(data);
        });
        return defer.promise;
    };

    return o;
}]);