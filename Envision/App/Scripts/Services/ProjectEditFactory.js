app.factory('ProjectEditFactory', ['$http', '$q', function ($http, $q) {
    var p = {};
    p.EditProject = {};

    p.EditedProject = function (EditProject, id) {
        var defer = $q.defer();
        var config = { contentType: 'applicaion/json' };
        $http.post('/api/apiProjectEdit/' + id, EditProject, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };

    //this goes to the projectedit api then it gets the project and sends it to the view
    p.getProjectbyId = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        console.log("Running");

        $http.get('/api/apiProjectEdit/' + id, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    return p;
}]);