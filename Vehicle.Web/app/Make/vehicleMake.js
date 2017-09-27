(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('vehicleMake', ['$scope', 'MakeService',





            function ($scope, MakeService) {
                var vm = $scope.vm = {};
                vm.maxSize = 5; 
                vm.pageNumber = 1; 
                vm.pageSize = 5;
                vm.totalCount = 0;
                vm.search = "";
                vm.datalength = 0;
                vm.vehicles = [];
                vm.vehicle = {};
                vm.showEdit = false;

                vm.ShowEdit = function (data) {
                    vm.showList = false,
                    vm.showEdit = true,
                    vm.vehicle = data;
                };

                vm.Hide = function () {
                    vm.showList = true,
                        vm.showEdit = false;

                };

                  vm.fetch = function (search, pageNumber, pageSize) {
                      vm.showEdit = false;
                      console.log("filter " + vm.search, "page number " + vm.pageNumber, "page size" + vm.pageSize);
                      MakeService.GetVehicleMake(vm.search, vm.pageNumber, vm.pageSize).then(function (response) {
                          console.log(response.data);
                          vm.datalength = response.data.length;
                          console.log(response.data.length);
                        vm.vehicles = response.data;
                    }, function (response) {
                        console.log('Oops... something went wrong' + data.message);

                    });
                };
                  
                  vm.fetch();
                 

                vm.get = function (item) {
                    vm.selected = item;

                    MakeService.GetVehicleMake($scope.selected).then(function (data) {
                        console.log(data);
                        vm.vehicles = data;
                    }, function (data) {
                        console.log('Unable to get this' + data.message);

                    });
                  }; 
                vm.delete = function (id) {
                    console.log("DELETE");
                    MakeService.DeleteVehicleMake(id).then(function (data) {
                        console.log(data);
                        vm.fetch(vm.search, vm.pageNumber, vm.pageSize);
                    }, function (data) {
                        console.log('Unable to delete' + data.message);

                    });

                };
                vm.edit = function (item) {
                    vm.vehicle.Name = item.Name;
                    vm.vehicle.Abrv = item.Abrv;
                    vm.vehicle.Id = item.Id;
                    MakeService.EditVehicleMake(vm.vehicle).then(function (data) {
                        console.log(vm.vehicle);
                        console.log("Edited!");
                        vm.fetch(vm.search, vm.pageNumber, vm.pageSize);
                        vm.vehicle = {};
                        
                    }, function (data) {
                        console.log(vm.vehicle);
                        console.log('Unable to edit' + data.message);

                    });

                };





        }]);


})();