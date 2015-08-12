app.factory('CustomerContactEditFactory', ['$http', '$q', function ($http, $q, id) {
    var o = {};
    o.EditContact = {};

    o.EditedCustomerContact = function (EditContact, id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('/api/apiCustomerContactEdit/' + id, EditContact, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };

    o.getCustomerContactbyId = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiCustomerContactEdit/' + id, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    return o;
}]);