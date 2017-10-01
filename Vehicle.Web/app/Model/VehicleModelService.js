(function () {
    'use strict';

    angular
        .module('vehicleApp')
        .factory('ModelService', ['$http', function ($http) {
            var defaulturl = 'http://localhost:1501/api/VehicleModel';

            return {
                GetVehicleModel: function (search, pageNumber, pageSize) {
                    return $http.get(defaulturl + '?Filter=' + search + '&pageNumber=' + pageNumber + '&pageSize=' + pageSize);
                },

                DeleteVehicleModel: function (id) {
                    var req = {
                        method: 'DELETE',
                        url: defaulturl + "/" + id,
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
                        }
                    };
                    return $http(req);
                },

                EditVehicleModel: function (item) {
                    return $http.put(defaulturl + "/" + item.id, { Id: item.Id, MakeId:item.MakeId, Name: item.Name, Abrv: item.Abrv });
                },

                AddVehicleModel: function (item) {
                    return $http.post(defaulturl, { Id: item.Id, MakeId: item.MakeId, Name: item.Name, Abrv: item.Abrv });
                },

                GetVehicleByMake: function (makeId, pageNumber, pageSize) {
                    return $http.get(defaulturl + '?makeId=' + makeId + '&pageNumber=' + pageNumber + '&pageSize=' + pageSize);
                }


            };
        }]);


})();