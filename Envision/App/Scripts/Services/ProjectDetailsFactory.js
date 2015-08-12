app.factory('ProjectDetailsFactory', ['$http', '$q', function ($http, $q, defer) {
    var o = {};
    o.Project = {};
    o.Projects = [];

    o.GetProject = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiProjectDetails/' + id, config).success(function (data) {
            o.project = data;
            defer.resolve(data);
        });
        return defer.promise;
    };

    //added 8-5-2015
    o.DeleteProject = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('/api/apiProjectDetails/' + id, config).success(function (data) {
            defer.resolve();
        });
        return defer.promise;
    };

    var getAllProjects = function () {
        var config = { contentType: 'application/json' };
        $http.get('/api/apiProjectDetails/', config).success(function (data) {
            o.Projects.length = 0;
            for (var i = 0; i < data.length; i++) {
                o.Projects[i] = data[i];
            }
        }).error(function (data, status) {
            if (status == 401) {
                $location.path('/Home')
            }
        }
        );
    };

    getAllProjects();
    return o;
}]);