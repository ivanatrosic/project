(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .factory('MakeService', ['$http', function ($http) {
            var defaulturl = 'http://localhost:1501/api/VehicleMake';

            return {
                GetAllVehicleMake: function (pageNumber = 1, pageSize = 5) {
                    return $http.get(defaulturl + '/' + pageNumber + '/' + pageSize);
                },

                GetVehicleMake: function (id) {
                    return $http.get(defaulturl+ '/'+id);
                }

            };
        }]);


})();