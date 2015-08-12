app.factory('UserFactory', ['$http', '$q', function ($http, $q) {
    var o = {};

    o.setToken = function (token) {
        localStorage.setItem('token', token);
    };

    o.getToken = function () {
        return localStorage.getItem('token');
    };

    o.removeToken = function () {
        localStorage.removeItem('token');
    };

    o.isInRole = function (role) {
        if (o.status.roles.indexOf(role) !== -1)
        { return true }
        else { return false }
    };

    o.getRoles = function () {
        var q = $q.defer();
        $http.get('/api/apiRoles').success(function (data) {
            o.status.roles.length = 0;
            if (data[0] != 0)
                for (i = 0; i < data.length; i++) {
                    o.status.roles.push(data[i]);
                }
            q.resolve(o.status.roles);
        });
        return q.promise;
    };

    o.login = function (user) {
        var q = $q.defer();
        $http.post('/Token', 'username=' + user.username + '&password=' + user.password + '&grant_type=password', { contentType: 'application/x-www-form-urlencoded' }).success(function (data) {
            o.setToken(data.access_token);
            o.getRoles().then(function (roles) {
                q.resolve(roles);
            });
        }).error(function (data) {
            q.reject(data.error_description);
        });
        return q.promise;
    };

    o.logout = function () {
        o.removeToken();
        o.status.roles.length = 0;
    };

    o.status = {};
    o.status.roles = [];
    o.status.isLoggedIn = (o.getToken()) ? true : false;
    if (o.status.isLoggedIn) o.getRoles();

    return o;
}]);