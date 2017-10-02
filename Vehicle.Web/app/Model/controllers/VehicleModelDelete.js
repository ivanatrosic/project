(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('VehicleModelDelete', ['$scope', 'ModelService', '$stateParams',





            function ($scope, ModelService, $stateParams) {
                var vm = $scope.vm = {};
                vm.vehicledelete = {};



                vm.getvehicle = function () {
                    vm.vehicledelete.Id = $stateParams.id;
                    ModelService.GetOneModel(vm.vehicledelete.Id).then(function (response) {
                        console.log(response);
                        vm.vehicledelete = response.data;
                    }, function (response) {
                        console.log('Unable to get this' + response.message);

                    });
                };


                vm.delete = function (item) {
                    var id = item.Id;
                    console.log("DELETE");
                    ModelService.DeleteVehicleModel(id).then(function (data) {
                        console.log(data);
                    }, function (data) {
                        console.log('Unable to delete' + data.message);

                    });

                };


            }]);


})();