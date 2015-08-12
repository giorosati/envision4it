app.controller('HardwareController', ['$scope', '$location', 'HardwareFactory', '$routeParams', '$q', function ($scope, $location, HardwareFactory, $routeParams, $q) {
    //Display on harware.html
    $scope.hardware = HardwareFactory.Hardware;

    $scope.AddToSolution = function (HardwareID) {
        HardwareFactory.AddToSolution(HardwareID, $routeParams.id).then(function (data) {
            $scope.addedHard = data;
            alert("Hardware Added!");
        });
    };

    //Edit
    //Pre Populate ng-model
    HardwareFactory.getHardwareById($routeParams.id).then(function (data) {
        $scope.hardwareGetEdit = data;
    });

    //ng-clickSaveEdit
    $scope.SaveHardware = function () {
        //sending the ng-model and the HardwareID
        HardwareFactory.EditHardware($scope.hardwareGetEdit, $routeParams.id).then(function (data) {
            $scope.editedHardware = data;
            $location.path('/AdminHome');
        });
    };
}]);