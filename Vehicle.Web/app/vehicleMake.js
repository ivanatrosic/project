(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .controller('vehicleMake', function ($scope, $http) {
            $scope.getall = function () {
                $scope.vehicles = [];
                $scope.title = "loading...";
                $http.get('http://localhost:1501/api/VehicleMake').then(function (data) {
                    console.log(data);
                    $scope.vehicles = data;
                }, function (data) {
                    console.log('Oops... something went wrong' + data.message);

                });
            };
            $scope.getall();
            $scope.add = function () {


            };
        });


})();