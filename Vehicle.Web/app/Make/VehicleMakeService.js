(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .factory('MakeService', ['$http', function ($http) {
            var defaulturl = 'http://localhost:1501/api/VehicleMake';

            return {
                GetVehicleMake: function (search, pageNumber, pageSize) {
                    return $http.get(defaulturl + '?Filter=' + search + '&pageNumber=' + pageNumber + '&pageSize=' + pageSize);
                },

                DeleteVehicleMake: function (id) {
                    var req = {
                        method: 'DELETE',
                        url: defaulturl + "/" + id,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                        }
                    };
                    return $http(req);
                },

            EditVehicleMake: function (item) {
                return $http.put(defaulturl + "/" + item.id, {Id:item.Id, Name:item.Name, Abrv:item.Abrv});
                }
            };
        }]);


})();