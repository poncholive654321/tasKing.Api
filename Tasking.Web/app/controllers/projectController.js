'use strict';
app.controller('projectController', ['$scope', '$rootScope', '$location', 'projectsService', function ($scope, $rootScope, $location, projectsService) {

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

}]);