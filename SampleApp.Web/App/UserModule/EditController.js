'use strict';

var EditController = function ($scope, $location, $routeParams, userService) {
    $scope.action = 'Update';
    var id = $routeParams.editId;
    $scope.item = userService.get({ id: id });

    $scope.save = function () {
        if ($scope.form.$invalid) return false;
        userService.update({ id: id }, $scope.item, function () {
            $location.path('/');
        });
    };
};

