(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('VehicleMakeCreate', ['$scope', 'MakeService',





            function ($scope, MakeService) {
                var vm = $scope.vm = {};

                vm.vehicle = {};


                vm.add = function (item) {
                    vm.vehicle.Name = item.Name;
                    vm.vehicle.Abrv = item.Abrv;

                    MakeService.AddVehicleMake(vm.vehicle).then(function (data) {
                        console.log(vm.vehicle);
                        console.log("Added!");
                        vm.vehicle = {};

                    }, function (data) {
                        console.log(vm.vehicle);
                        console.log('Unable to add' + data.message);

                    });


                };

            }]);


})();