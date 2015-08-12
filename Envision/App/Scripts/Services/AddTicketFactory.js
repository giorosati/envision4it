app.factory('AddTicketFactory', ['$http', '$q', function ($http, $q) {
    var o = {};

    o.addTicket = function (ticket, id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('api/apiAddTicket/' + id, ticket, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);