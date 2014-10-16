'use strict';
app.factory('projectsService', ['$http', function ($http) {

    var serviceBase = 'http://localhost:52509/';
    var projectsServiceFactory = {};

    var _getAllProjectsByUser = function () {

        return $http.get(serviceBase + 'api/projects').then(function (results) {
            return results;
        });
    };

    ordersServiceFactory.getAllProjectsByUser = _getProjectsByUser;

    return projectsServiceFactory;

}]);