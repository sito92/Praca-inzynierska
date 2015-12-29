app.controller('NewsController', function ($scope, NewsService,SettingsService,$sce,$window) {
    $scope.page = 1;

    var refresh = function () {
        NewsService.getPaginatedNews($scope.newsPerPage,$scope.page).then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.newsAmount = jsonResult.newsAmount;
                $scope.newses = jsonResult.data;
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    SettingsService.getByName("ShowingNewsNumber").then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.newsPerPage = jsonResult.data;
            
            refresh();
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });
    $scope.getPageNumber = function () {
        if ($scope.newsAmount != null && $scope.newsAmount > 0 && $scope.newsPerPage > 0) {
            var pages = $scope.newsAmount / $scope.newsPerPage;
            var numbers = [];
            for (var i = 1; i <= pages; i++) {
                numbers.push(i);
            }
            return numbers;
        }
    }
    $scope.changePage = function(page) {
        $scope.page = page;
    }
    $scope.$watch("page", function (newVal, oldVal) {
        if (newVal!=oldVal)
        refresh();
    });
    $scope.trusted = function(content) {
        return $sce.trustAsHtml(content);
    }
    $scope.goTo = function(news) {
        $window.location.href = '/News/Show/'+news.Id;
    }
    $scope.first = function() {
        $scope.page = 1;
    }
    $scope.last = function () {
        $scope.page = $scope.getPageNumber().length;
    }
});
