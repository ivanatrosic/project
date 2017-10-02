(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('VehicleMakeUpdate', ['$scope', 'MakeService', '$stateParams',





            function ($scope, MakeService, $stateParams) {
                var vm = $scope.vm = {};
                vm.vehicleupdate = {};



                vm.getvehicle = function () {
                    vm.vehicleupdate.Id = $stateParams.id;
                    MakeService.GetOneMake(vm.vehicleupdate.Id).then(function (response) {
                        console.log(response);
                        vm.vehicleupdate = response.data;
                    }, function (response) {
                        console.log('Unable to get this' + response.message);

                    });
                }; 


                vm.edit = function (item) {
                    vm.vehicleupdate.Name = item.Name;
                    vm.vehicleupdate.Abrv = item.Abrv;
                    vm.vehicleupdate.Id = item.Id;
                    MakeService.EditVehicleMake(vm.vehicleupdate).then(function (data) {
                        console.log(vm.vehicleupdate);
                        console.log("Edited!");
                        vm.vehicle = {};

                    }, function (data) {
                        console.log(vm.vehicleupdate);
                        console.log('Unable to edit' + data.message);

                    });
                };


            }]);


})();