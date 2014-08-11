var ListController = function ($scope, $location, userService) {
    //$scope.users = [{ "Id": 1, "Name": "User 1", "EmailAddress": "user1@email.com" },
    //    { "Id": 2, "Name": "User 2", "EmailAddress": "user2@email.com" },
    //    { "Id": 3, "Name": "User 3", "EmailAddress": "user3@email.com" },
    //    { "Id": 4, "Name": "User 4", "EmailAddress": "user4@email.com" },
    //    { "Id": 5, "Name": "User 5", "EmailAddress": "user5@email.com" }
    //];

    $scope.search = function () {
        userService.query({
            q: $scope.query,
            sort: $scope.sort_order,
            desc: $scope.is_desc,
            offset: $scope.offset,
            limit: $scope.limit
        },
            function (data) {
                $scope.more = data.length === 10;
                $scope.users = $scope.users.concat(data);
            });
    };

    $scope.sort = function (col) {
        if ($scope.sort_order === col) {
            $scope.is_desc = !$scope.is_desc;
        } else {
            $scope.sort_order = col;
            $scope.is_desc = false;
        }
        $scope.reset();
    };

    $scope.show_more = function () {
        $scope.offset += $scope.limit;
        $scope.search();
    };

    $scope.has_more = function () {
        return $scope.more;
    }

    $scope.reset = function () {
        $scope.limit = 10;
        $scope.offset = 0;
        $scope.users = [];
        $scope.more = true;
        $scope.search();
    };

    $scope.delete = function () {
        var id = this.user.Id;
        userService.delete({ id: id }, function () {
            $('#user_' + id).fadeOut();
        });
    };

    $scope.sort_order = 'Name';
    $scope.is_desc = false;


    $scope.reset();
};