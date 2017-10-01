(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('vehicleModel', ['$scope', 'ModelService',





            function ($scope, ModelService) {
                var vm = $scope.vm = {};
                vm.maxSize = 5;
                vm.pageNumber = 1;
                vm.pageSize = 5;
                vm.totalCount = 0;
                vm.search = "";
                vm.datalength = 0;
                vm.vehicles = [];
                vm.vehicle = {};
                vm.showTable = true;
                vm.showEdit = false;
                vm.showAdd = false;
                vm.MakeIdSearch = null;

                vm.ShowEdit = function (data) {
                    vm.showTable = false,
                        vm.showEdit = true,
                        vm.showAdd = false,
                        vm.vehicle = data;
                };

                vm.Hide = function () {
                    vm.showTable = true,
                        vm.showAdd = false,
                        vm.showEdit = false;

                };
                vm.ShowAdd = function () {
                    vm.showTable = false,
                        vm.showAdd = true,
                        vm.showEdit = false;

                };

                vm.fetch = function (search, pageNumber, pageSize) {
                    console.log("filter " + vm.search, "page number " + vm.pageNumber, "page size" + vm.pageSize);
                    ModelService.GetVehicleModel(vm.search, vm.pageNumber, vm.pageSize).then(function (response) {
                        console.log(response.data);
                        vm.datalength = response.data.length;
                        console.log(response.data.length);
                        vm.vehicles = response.data;
                    }, function (response) {
                        console.log('Oops... something went wrong' + data.message);

                    });
                };

                vm.fetch();

                vm.searchByMake = function (MakeIdSearch, pageNumber, pageSize) {
                    console.log("MakeIdSearch " + vm.MakeIdSearch, "page number " + vm.pageNumber, "page size" + vm.pageSize);
                    ModelService.GetVehicleByMake(MakeIdSearch, vm.pageNumber, vm.pageSize).then(function (response) {
                        console.log(response.data);
                        vm.datalength = response.data.length;
                        console.log(response.data.length);
                        vm.vehicles = response.data;
                        vm.MakeIdSearch = null;
                    }, function (response) {
                        console.log('Oops... something went wrong' + data.message);

                    });
                };
                vm.get = function (item) {
                    vm.selected = item;

                    ModelService.GetVehicleModel($scope.selected).then(function (data) {
                        console.log(data);
                        vm.vehicles = data;
                    }, function (data) {
                        console.log('Unable to get this' + data.message);

                    });
                };
                vm.delete = function (item) {
                    var id = item.Id;
                    console.log("DELETE");
                    ModelService.DeleteVehicleModel(id).then(function (data) {
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
                    vm.vehicle.MakeId = item.MakeId;
                    ModelService.EditVehicleModel(vm.vehicle).then(function (data) {
                        console.log(vm.vehicle);
                        console.log("Edited!");
                        vm.fetch(vm.search, vm.pageNumber, vm.pageSize);
                        vm.vehicle = {};
                        vm.Hide();

                    }, function (data) {
                        console.log(vm.vehicle);
                        console.log('Unable to edit' + data.message);

                    });
                };
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