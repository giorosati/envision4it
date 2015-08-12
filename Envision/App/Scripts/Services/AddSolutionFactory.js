app.factory('AddSolutionFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.solution = {};

    o.AddSolution = function (id, solution) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('api/apiSolution/' + id, solution, config).success(function (data) {
            defer.resolve(data);
        });

        return defer.promise;
    };
    return o;
}]);