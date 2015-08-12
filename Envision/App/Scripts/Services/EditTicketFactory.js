app.factory('EditTicketFactory', ['$q', '$http', function ($q, $http, id) {
    var o = {};
    o.getTicket = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiTicket/' + id, config).success(function (data) {
            defer.resolve(data);
        }).error(function (data) {
            console.log(data);
        });
        return defer.promise;
    };

    o.EditTicket = function (EditedTicket, id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('/api/apiTicket/' + id, EditedTicket, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);