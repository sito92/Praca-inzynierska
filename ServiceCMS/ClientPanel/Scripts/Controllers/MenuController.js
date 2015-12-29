app.controller('MenuController', function ($scope, MenuService) {
        MenuService.getMenuData().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.model = jsonResult.data;
                console.log($scope.model);

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    
});
