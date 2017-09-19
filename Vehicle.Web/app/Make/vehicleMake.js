(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('vehicleMake', ['$scope', 'MakeService',





            function ($scope, MakeService) {
                var vm = $scope.vm = {};
                vm.pageNumber = 1;
                vm.pageSize = 5;
                vm.Filter = "";
                  vm.vehicles = [];

                  vm.getall = function (Filter, pageNumber, pageSize) {
                      console.log("filter " + vm.Filter,"page number " + vm.pageNumber, "page size" + vm.pageSize)
                      MakeService.GetAllVehicleMake(vm.Filter, vm.pageNumber, vm.pageSize).then(function (response) {
                          console.log(response.data);
                        vm.vehicles = response.data;
                    }, function (response) {
                        console.log('Oops... something went wrong' + data.message);

                    });
                };

                vm.getall();

                vm.get = function (item) {
                    vm.selected = item;

                    MakeService.GetVehicleMake($scope.selected).then(function (data) {
                        console.log(data);
                        vm.vehicles = data;
                    }, function (data) {
                        console.log('Unable to get this' + data.message);

                    });

            };
        }]);


})();