(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('vehicleMake', ['$scope', 'MakeService',





            function ($scope, MakeService) {
                var vm = $scope.vm = {};
                vm.maxSize = 5; // Limit number for pagination display number
                vm.pageNumber = 1; // Current page number
                vm.pageSize = 5;//  number of items per page
                vm.totalCount = 0;
                vm.Filter = "";

                  vm.vehicles = [];

                  vm.getMake = function (Filter, pageNumber, pageSize) {

                      console.log("filter " + vm.Filter,"page number " + vm.pageNumber, "page size" + vm.pageSize)
                      MakeService.GetVehicleMake(vm.Filter, vm.pageNumber, vm.pageSize).then(function (response) {
                          console.log(response.data);
                        vm.vehicles = response.data;
                    }, function (response) {
                        console.log('Oops... something went wrong' + data.message);

                    });
                };
                  vm.pageChangeHandler = function (num) {
                      console.log('meals page changed to ' + num);
                  };
                  vm.getMake();
                  //This method is calling from pagination number  
                  vm.pageChanged = function () {
                      vm.getMake();
                  }; 

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