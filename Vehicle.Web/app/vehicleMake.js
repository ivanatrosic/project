(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('vehicleMake', ['$scope', 'MakeService',





            function ($scope, MakeService) {

                  $scope.pageNumber= 1
                  $scope.pageSize= 5
                  $scope.vehicles = [];

                $scope.getall = function () {
                    console.log("page number " + $scope.pageNumber, "page size" + $scope.pageSize)
                    MakeService.GetAllVehicleMake().then(function (response) {
                        console.log(response.data);
                        $scope.vehicles = response.data;
                    }, function (response) {
                        console.log('Oops... something went wrong' + data.message);

                    });
                };

                $scope.getall();

                $scope.get = function (item) {
                    $scope.selected = item;

                    MakeService.GetVehicleMake($scope.selected).then(function (data) {
                        console.log(data);
                        $scope.vehicles = data;
                    }, function (data) {
                        console.log('Unable to get this' + data.message);

                    });

            };
        }]);


})();