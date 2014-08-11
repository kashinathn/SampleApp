'use strict';

var UserApp = angular.module("UserApp", ['ngRoute', 'ngResource']).
    config(function ($routeProvider) {
        $routeProvider
                .when('/', { controller: ListController, templateUrl: 'App/UserModule/list.html' })
                .when('/new', { controller: CreateController, templateUrl: 'App/UserModule/details.html' })
                .when('/edit/:editId', { controller: EditController, templateUrl: 'App/UserModule/details.html' })
                .otherwise({ redirectTo: '/' });
        }
    );

UserApp.factory('userService', function ($resource) {
    return $resource('api/user/:id', { id: '@id' }, { update: { method: 'PUT' } });
});


