app.factory('NewCustomerContactFactory', ['$http', '$q', function ($http, $q) {
    var o = {};

    o.NewCustomerContact = function (contact) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('api/apiNewCustomerContact', contact, config).success(function (data) {
            defer.resolve(data);
        }).error(function (data, status) {
            console.log(data);
            console.log(status);
        });
        return defer.promise;
    };
    return o;
}]);