(function () {
    'use strict';
    angular.module('vehicleApp')
        .config(['$stateProvider', '$urlRouterProvider',
            function ($stateProvider, $urlRouterProvider) {
                $urlRouterProvider.otherwise('/');

                $stateProvider.state('Make', {
                    url: '/make',
                    templateUrl: 'app/Make/views/Make.html',
                    controller: 'vehicleMake'
                });
                $stateProvider.state('CreateMake', {
                    url: '/make/create',
                    templateUrl: 'app/Make/views/CreateMake.html',
                    controller: 'VehicleMakeCreate'
                });
                $stateProvider.state('UpdateMake', {
                    url: '/make/update/:id',
                    templateUrl: 'app/Make/views/UpdateMake.html',
                    controller: 'VehicleMakeUpdate'
                });
                $stateProvider.state('DeleteMake', {
                    url: '/make/delete/:id',
                    templateUrl: 'app/Make/views/DeleteMake.html',
                    controller: 'VehicleMakeDelete'
                });
                $stateProvider.state('Model', {
                    url: '/model',
                    templateUrl: 'app/Model/Model.html',
                    controller: 'vehicleModel'
                });

            }]);
})();