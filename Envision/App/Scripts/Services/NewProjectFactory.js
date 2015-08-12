app.factory('NewProjectFactory', ['$http', '$q', function ($http, $q) {
    var o = {};

    o.NewProject = function (project) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('api/apiNewProject', project, config).success(function (data) {
            defer.resolve(data);
        }).error(function(data, status)
        {

            console.log(data);
            console.log(status);
        }
        
        );

        return defer.promise;
    };
    return o;
}]);