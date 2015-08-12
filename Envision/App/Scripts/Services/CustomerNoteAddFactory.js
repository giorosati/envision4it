app.factory('CustomerNoteAddFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.customerNote = {};

    o.customerNoteAdd = function (customerNote, id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('api/apiCustNoteNew/' + id, customerNote, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);