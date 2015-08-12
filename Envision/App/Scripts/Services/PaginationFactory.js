app.factory('PaginationFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.projects = [];
    o.totalprojects = 10;
    o.DeleteProject = function (id) {
        var config = { contentType: 'application/json' };
        $http.post('/api/apiAdmin/' + id, config).success(function (data) {
        });
    };

    o.getprojects = function (currentPage, count) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiAdmin/' + currentPage + '/' + count, config).success(function (data) {
            defer.resolve(data);
        }).error(function (data, status) {
            console.log(data);
            console.log(status);
        });

        return defer.promise;
    };
    $http.get('/api/apiNewProject/totalcount').success(function (data) {
        o.totalprojects = data;
        o.getprojects(1, 4);
    })
    return o;
}]);