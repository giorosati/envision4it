app.factory('CustomerNoteDetailsFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.note = {};

    o.getNote = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiCustomerNote/' + id, config).success(function (data) {
            o.note = data;
            defer.resolve(data);
        });
        return defer.promise;
    };

    return o;
}]);