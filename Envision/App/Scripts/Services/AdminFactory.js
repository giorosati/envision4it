app.factory('AdminFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.Projects = [];

    o.DeleteProject = function (id) {
        var config = { contentType: 'application/json' };
        $http.post('/api/apiAdmin/' + id, config).success(function (data) {
            console.log(o.Projects)
            for (var i = 0; i < o.Projects.length; i++) {
                if (o.Projects[i].ProjectID == id) {
                    o.Projects.splice(i, 1);
                    break;
                }
            };
        });
    };

    o.DeleteSolution = function (solution, project) {
        var config = { contentType: 'application/json' };
        $http.post('/api/apiDelSol/' + solution.SolutionID, config).success(function (data) {
            var pindex = o.Projects.indexOf(project);
            var sindex = o.Projects[pindex].Solutions.indexOf(solution);
            o.Projects[pindex].Solutions.splice(sindex, 1);
        });
    };

    var getAllProjects = function (project) {
        var config = { contentType: 'application/json' };
        $http.get('/api/apiAdmin/', project, config).success(function (data) {
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