'use strict';
app.factory('projectsService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:52509/';
    var projectsServiceFactory = {};

    var _getAllProjectsByUser = function () {
        return $http.get(serviceBase + 'api/projects').then(function (results) {
            return results;
        });
    };

    var _createNewProject = function (dto) {
        return $http.post(serviceBase + 'api/projects', dto).then(function (results) {
            return results;
        });
    };

    var _deleteProject = function (projectId) {
        return $http.delete(serviceBase + 'api/projects', { projectId: projectId }).then(function (results) {
            return results;
        });
    }

    projectsServiceFactory.getAllProjectsByUser = _getAllProjectsByUser;
    projectsServiceFactory.createNewProject = _createNewProject;
    projectsServiceFactory.deleteProject = _deleteProject;

    return projectsServiceFactory;

}]);