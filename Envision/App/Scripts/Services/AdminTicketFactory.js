app.factory('AdminTicketFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.ticket = {};
    o.getTickets = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('api/apiTicket/', config).success(function (data) {
            o.ticket = data;
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);