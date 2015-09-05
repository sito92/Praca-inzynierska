app.controller('LeftMenuController', function ($scope) {

    $scope.toggled = false;
    $scope.open = function() {
        $scope.toggled = true;
    }
    $scope.close = function () {
        $scope.toggled = false;
    }
    $scope.$watch("toggled", function (oldVAl, newVal) {
        $("#wrapper").toggleClass("toggled");
    });
});
