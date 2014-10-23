'use strict';
app.controller('indexController', ['$scope', '$location', 'authService', 'projectsService', function ($scope, $location, authService, projectsService) {

    var refreshProjects = function () {
        projectsService.getAllProjectsByUser().then(function (results) {
            $scope.projects = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    }
    
    $scope.logOut = function () {
        authService.logOut();
        $location.path('/home');
    }

    $scope.authentication = authService.authentication;

    $scope.projects = [];

    refreshProjects();

    $scope.$on('newProjectCreated', function (event, data) {
        refreshProjects();
    });

    $scope.$on('projectDeleted', function (event, data) {
        refreshProjects();
    });

}]);