'use strict';
app.controller('ordersController', ['$scope', 'ordersService', function ($scope, ordersService) {

    $scope.orders = [];

    ordersService.getOrders().then(function (results) {

        $scope.projects = results.data;

    }, function (error) {
        //alert(error.data.message);
    });

}]);