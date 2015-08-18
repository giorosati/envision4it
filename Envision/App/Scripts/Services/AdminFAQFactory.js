app.factory('AdminFAQFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.FAQ = {};
    o.getFAQs = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('api/apiFAQ/', config).success(function (data) {
            o.FAQ = data;
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);