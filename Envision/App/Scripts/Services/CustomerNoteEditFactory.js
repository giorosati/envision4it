app.factory('CustomerNoteEditFactory', ['$http', '$q', function ($http, $q, id) {
    var o = {};
    o.EditCustomerNote = {};

    o.EditedCustomerNote = function (EditCustomerNote, id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('api/apiCustomerNoteEdit' / +id, EditCustomerNote, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
}]);