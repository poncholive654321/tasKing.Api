'use strict';
app.controller('projectController', ['$scope', '$rootScope', '$location', 'projectsService', function ($scope, $rootScope, $location, projectsService) {

    $scope.id = 0;
    $scope.title = "";
    $scope.description = "";

    $scope.submit = function () {
        var dto = {
            "title": $scope.title,
            "description": $scope.description
        }
        projectsService.createNewProject(dto).then(function (result) {
            if (result.status == 200) {
                $location.path('/home');
                $rootScope.$broadcast('newProjectCreated', {});
            };
        });
    }

    $scope.delete = function () {
        if (confirm("This action cannot be undone...are you sure?")) {
            projectsService.deleteProject(1).then(function (result) {
                if (result.status == 200) {
                    $location.path('/home');
                    $rootScope.$broadcast('projectDeleted', {});
                };
            });
        }
    }

}]);