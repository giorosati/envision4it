app.factory('SolutionDetailsFactory', ['$http', '$q', '$location', function ($http, $q, $location) {
    var o = {};
    o.solution = {};

    o.DeleteHardware = function (hardwareid, id) {
        var ids = { HardwareID: hardwareid, SolutionID: id };
        var config = { contentType: 'application/json' };
        $http.post('/api/apiDelHard/', ids, config).success(function (data) {
        });
    };

    o.DeleteFAQ = function (id) {
        var config = { contentType: 'application/json' };
        $http.post('/api/apiDelFAQ/' + id, config).success(function (data) {
        });
    };

    o.DeleteTicket = function (id) {
        var config = { contentType: 'application.json' };
        $http.post('/api/apiDelTicket/' + id, config).success(function (data) {
            console.log('ran on factory');
        });
    };

    o.getSolById = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiCustSol/', config).success(function (data) {
            o.solution = data;
            defer.resolve(data);
        });
        return defer.promise;
    };

    o.getSolution = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiSolution/' + id, config).success(function (data) {
            o.solution = data;
            defer.resolve(data);
        });
        return defer.promise;
    };

    return o;
}]);