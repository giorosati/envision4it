app.factory('SolutionEditFactory', ['$http', '$q', function ($http, $q, id) {
    var p = {};
    p.EditSolution = {};

    p.EditedSolution = function (EditSolution, id) {
        var defer = $q.defer();
        console.log('this is what is being sent  ' + EditSolution);
        var config = { contentType: 'applicaion/json' };
        $http.post('/api/apiSolutionEdit/' + id, EditSolution, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };

    //this goes to the solution edit api then it gets the project and sends it to the view
    p.getSolutionbyId = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiSolutionEdit/' + id, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    return p;
}]);