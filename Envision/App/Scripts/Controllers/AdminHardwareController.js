app.controller('AdminHardwareController', ['$scope', '$location', 'AdminHardwareFactory', '$routeParams', '$q', function ($scope, $location, AdminHardwareFactory, $routeParams, $q) {

    //Display on hardware.html
    AdminHardwareFactory.getHardware($routeParams.id).then(function(data){
        $scope.hardware = data;

    //Edit
    //Pre Populate ng-model
    //AdminHardwareFactory.getHardware($routeParams.id).then(function (data) {
    //    $scope.hardwareGetEdit = data;
    //});

    //ng-clickSaveEdit
    //$scope.SaveHardware = function () {
    //    //sending the ng-model and the HardwareID
    //    AdminHardwareFactory.EditHardware($scope.hardwareGetEdit, $routeParams.id).then(function (data) {
    //        $scope.editedHardware = data;
    //        $location.path('/AdminHome');
    });
}]);