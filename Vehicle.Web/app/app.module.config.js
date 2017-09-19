(function () {
    'use strict';
    angular.module('vehicleApp')
        .config(['$stateProvider', '$urlRouterProvider',
            function ($stateProvider, $urlRouterProvider) {
                $urlRouterProvider.otherwise('/');

                $stateProvider.state('Make', {
                    url: '/make',
                    templateUrl: 'app/Make/Make.html',
                    controller: 'vehicleMake'
                }).state('Model', {
                    url: '/model',
                    templateUrl: 'app/Model/Model.html',
                    controller: 'vehicleModel'
                });
            }]);
})();