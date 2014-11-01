'use strict';
app.controller('collaboratorsController', ['$scope', function ($scope) {
    //https://docs.angularjs.org/tutorial/step_05 -> A Note on Minification

    $scope.collaborators = [];

    var refresh = function () {
        $scope.collaborators = [
            {}
        ]
    }

    refresh();

}]);