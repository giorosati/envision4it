app.factory('AdminHardwareFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.hardware = {};
    o.getHardware = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('api/apiAdminHardware/', config).success(function (data) {
            o.hardware = data;
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);