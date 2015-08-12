app.factory('CustomerContactDetailsFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.contact = {};

    o.getContact = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiCustomerContact/', config).success(function (data) {
            o.contact = data;
            defer.resolve(data);
        });
        return defer.promise;
    };

    return o;
}]);