(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('VehicleModelCreate', ['$scope', 'ModelService',





            function ($scope, ModelService) {
                var vm = $scope.vm = {};
                vm.vehiclemakes = [];
                vm.vehicle = {};
                vm.getmakes = function () {

                    ModelService.GetMakes().then(function (response) {
                        vm.vehiclemakes = response.data;
                        console.log(vm.vehiclemakes);

                    }, function (response) {
                        console.log('Unable to add' + response.message);

                    });
                };
                vm.getmakes();

                vm.add = function (item) {
                    vm.vehicle.Name = item.Name;
                    vm.vehicle.Abrv = item.Abrv;
                    vm.vehicle.Id = item.Id;
                    vm.vehicle.MakeId = item.MakeId;
                    ModelService.AddVehicleModel(vm.vehicle).then(function (data) {
                        console.log(vm.vehicle);
                        console.log("Added!");
                        vm.fetch(vm.search, vm.pageNumber, vm.pageSize);
                        vm.vehicle = {};
                        vm.Hide();

                    }, function (data) {
                        console.log(vm.vehicle);
                        console.log('Unable to add' + data.message);

                    });


                };

            }]);


})();