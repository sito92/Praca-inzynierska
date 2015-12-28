app.controller('StatisticsController', function ($scope, StatisticsService) {

    $scope.pageHtml = "";
    $scope.usersPerCountry = function () {
        StatisticsService.getPage("UsersPerCountry").then(function (jsonResult) {
            $scope.pageHtml = jsonResult;
        }, function () {
            alert("Error");

        });
    }
    $scope.usersForSelectedMonth = function () {
        StatisticsService.getPage("UsersForSelectedMonth").then(function (jsonResult) {
            $scope.pageHtml = jsonResult;
        }, function () {
            alert("Error");

        });
    }
    $scope.usersForEveryMonth = function () {
        StatisticsService.getPage("UsersForEveryMonth").then(function (jsonResult) {
            $scope.pageHtml = jsonResult;
        }, function () {
            alert("Error");

        });
    }
});
app.controller('UsersPerCountryController', function ($scope, StatisticsService) {
    $scope.model = {};
    StatisticsService.getUsersPerCountry().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.data = [];
            $scope.data.push(jsonResult.data.Visitors);
            $scope.labels = jsonResult.data.Keys;
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
        $modalInstance.dismiss();
    });

});
app.controller('UsersForSelectedMonthController', function ($scope, StatisticsService) {
    var date = new Date();
    $scope.month = date.getMonth()+1;
    $scope.year = date.getFullYear();
    $scope.date = date;

    $scope.$watch("date", function (newVal, oldVal) {
        $scope.month = newVal.getMonth()+1;
        $scope.year = newVal.getFullYear();

        refresh();
    });
    var refresh = function() {
        StatisticsService.getUsersForSelectedMonth($scope.month, $scope.year).then(function(jsonResult) {
            if (jsonResult.success) {
                $scope.data = [];
                $scope.data.push(jsonResult.data.Visitors);
                $scope.labels = jsonResult.data.Keys;
            } else {
                $scope.labels = [];
                $scope.data = [];
            }
        }, function() {
            alert("Error");
        });
    }
});
app.controller('UsersForEveryMonthController', function ($scope, StatisticsService) {
    var date = new Date();
    $scope.month = date.getMonth() + 1;
    $scope.year = date.getFullYear();
    $scope.date = date;

    $scope.$watch("date", function (newVal, oldVal) {
        $scope.year = newVal.getFullYear();
        refresh();
    });
    var refresh = function () {
        StatisticsService.getUsersForEveryMonth($scope.year).then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.data = [];
                $scope.data=jsonResult.data.Visitors;
                $scope.labels = jsonResult.data.Keys;
            } else {
                $scope.labels = [];
                $scope.data = [];
            }
        }, function () {
            alert("Error");
        });
    }

});