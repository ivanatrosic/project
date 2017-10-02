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


                  vm.fetch = function (search, pageNumber, pageSize) {
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
                 





        }]);


})();