(function () {
    'use strict';

    angular
        .module('app')
        .controller('HomeCtrl', HomeCtrl);

    HomeCtrl.$inject = ['$scope','$http'];

    function HomeCtrl($scope, $http) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'HomeCtrl';

        activate();

        function activate() { }

        $scope.click = function () {
            var serviceUrl = 'http://customer-service.azurewebsites.net/api/clientes';
            $http.get(serviceUrl)
                .success(function (result, status, headers, config) {
                    console.log(result);
                });
        }
    }
})();
