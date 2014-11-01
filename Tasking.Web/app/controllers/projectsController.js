'use strict';
app.controller('projectsController', ['$scope', 'projectsService', function ($scope, projectsService) {

    $scope.projects = [];
    
    var refresh = function () {
        projectsService.getAllProjectsByUser().then(function (results) {
            $scope.projects = results.data;
        }, function (error) {
            //alert(error.data.message);
        });
    }

    $scope.delete = function (id) {
        if (confirm("This action cannot be undone...are you sure?")) {
            projectsService.deleteProject(id).then(function (result) {
                if (result.status == 200) {
                    refresh();
                };
            });
        }
    }

    refresh();

}]);