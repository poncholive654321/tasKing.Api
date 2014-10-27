﻿var app = angular.module('tasKingWebApp', ['ngRoute', 'LocalStorageModule', 'angular-loading-bar']);

app.config(function ($routeProvider) {

    $routeProvider.when("/home", {
        controller: "homeController",
        templateUrl: "/app/views/home.html"
    });

    $routeProvider.when("/login", {
        controller: "loginController",
        templateUrl: "/app/views/login.html"
    });

    $routeProvider.when("/signup", {
        controller: "signupController",
        templateUrl: "/app/views/signup.html"
    });

    $routeProvider.when("/orders", {
        controller: "ordersController",
        templateUrl: "/app/views/orders.html"
    });

    $routeProvider.when("/projects", {
        controller: "projectsController",
        templateUrl: "/app/views/projects.html"
    });

    $routeProvider.when("/project", {
        controller: "projectController",
        templateUrl: "/app/views/project.html",
        resolve: {
            selected: function () {
                return { data: undefined };
            }
        }
    });

    $routeProvider.when("/project/:id", {
        controller: "projectController",
        templateUrl: "/app/views/project.html",
        resolve: {
            selected: function ($route, projectsService) {
                return projectsService.getById($route.current.params.id);
            }
        }
    });

    $routeProvider.when("/dashboard", {
        controller: "dashboardController",
        templateUrl: "/app/views/dashboard.html"
    });

    $routeProvider.otherwise({ redirectTo: "/home" });
});

app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});

app.run(['authService', function (authService) {
    authService.fillAuthData();
}]);