'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', 'projectsService', function ($scope, $location, authService, projectsService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

}]);