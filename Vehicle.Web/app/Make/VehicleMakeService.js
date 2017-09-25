(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .factory('MakeService', ['$http', function ($http) {
            var defaulturl = 'http://localhost:1501/api/VehicleMake';

            return {
                GetVehicleMake: function (Filter, pageNumber, pageSize) {
                    return $http.get(defaulturl + '?Filter=' + Filter + '&pageNumber=' + pageNumber + '&pageSize=' + pageSize);
                },

                //GetVehicleMake: function (id) {
                //    return $http.get(defaulturl+ '/'+id);
                //}

            };
        }]);


})();