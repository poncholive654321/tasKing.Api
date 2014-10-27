'use strict';
app.factory('projectsService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:52509/';
    var projectsServiceFactory = {};

    var _getAllProjectsByUser = function () {
        return $http.get(serviceBase + 'api/projects');
    };

    var _getById = function (id) {
        return $http.get(serviceBase + 'api/projects?id=' + id).then(function (results) {
            return results;
        });
        //var promise = $http({ method: 'GET', url: serviceBase + 'api/projects?id=' + id }).success(function (data, status, headers, config) {
        //    return data;
        //});
        //return promise;
    };

    var _createNewProject = function (dto) {
        dto.action = 'POST';
        return $http.post(serviceBase + 'api/projects', dto).then(function (results) {
            return results;
        });
    };

    var _deleteProject = function (projectId) {
        var dto = { id: projectId, action: 'DELETE' };
        return $http.post(serviceBase + 'api/projects', dto).then(function (results) {
            return results;
        });
    }

    projectsServiceFactory.getAllProjectsByUser = _getAllProjectsByUser;
    projectsServiceFactory.createNewProject = _createNewProject;
    projectsServiceFactory.deleteProject = _deleteProject;
    projectsServiceFactory.getById = _getById;

    return projectsServiceFactory;

}]);