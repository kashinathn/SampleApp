'use strict';

var CreateController = function ($scope, $location, userService) {
    $scope.action = 'Add';
    $scope.save = function () {
        if ($scope.form.$invalid) return false;
        userService.save($scope.item, function () {
            $location.path('/');
        });
    };
};



