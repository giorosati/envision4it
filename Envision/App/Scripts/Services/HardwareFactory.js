app.factory('HardwareFactory', ['$http', '$q', function ($http, $q) {
    var o = {};
    o.Hardware = [];

    o.getHardware = function () {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiHardware/', config).success(function (data) {
            o.Hardware.length = 0;
            for (var index = 0; index < data.length; index++) {
                o.Hardware[index] = data[index];
            }
        }).error(function (data) {
        });
        return defer.promise;
    };

    o.getHardware();

    o.AddToSolution = function (HardwareID, SolutionID) {
        var defer = $q.defer();
        var storedIDs = { HardwareID: HardwareID, SolutionID: SolutionID };
        var config = { contentType: 'application/json' };
        $http.post('/api/apiHardware/', storedIDs, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };
    //Update Functionality
    o.getHardwareById = function (id) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.get('/api/apiHardwareEdit/' + id, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };

    o.EditHardware = function (editedHardware, HardwareID) {
        var defer = $q.defer();
        var config = { contentType: 'application/json' };
        $http.post('/api/apiHardwareEdit/' + HardwareID, editedHardware, config).success(function (data) {
            defer.resolve(data);
        });
        return defer.promise;
    };

    return o;
}]);