'use strict';
app.controller('projectController', ['$scope', '$rootScope', '$location', 'projectsService', 'selected', function ($scope, $rootScope, $location, projectsService, selected) {

    $scope.model = {};
    $scope.model.id = 0;
    $scope.model.title = "";
    $scope.model.description = "";

    $scope.submit = function () {
        //var dto = {
        //    "title": $scope.title,
        //    "description": $scope.description
        //}
        projectsService.createNewProject($scope.model).then(function (result) {
            if (result.status == 200) {
                $location.path('/projects');
                $rootScope.$broadcast('newProjectCreated', {});
            };
        });
    }

    $scope.delete = function () {
        if (confirm("This action cannot be undone...are you sure?")) {
            projectsService.deleteProject($scope.model.id).then(function (result) {
                if (result.status == 200) {
                    $location.path('/projects');
                    $rootScope.$broadcast('projectDeleted', {});
                };
            });
        }
    }

    if (selected.data) {
        $scope.model = selected.data;
    }

}]);