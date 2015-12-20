app.controller('NewsController', function ($scope, $modal) {


    $scope.add = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=Add',
            controller: 'NewsAddModalCtrl',
            size: "lg"
        });
        modalInstance.result.then(function () {
            //refresh();
        });
    };
});
app.controller('NewsAddModalCtrl', function ($scope, $modalInstance, $filter, $modal,NewsService) {
    $scope.news =
{
    Tilte: "",
    Content: "",
    Categories: [
    ]
}
    $scope.send = function () {

    };
    $scope.add = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=ChooseCategory',
            controller: 'NewsChooseCategoryModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (category) {
            if (category != undefined) {
                var found = $filter('filter')($scope.news.Categories, { Id: category.Id });
                if (found.length <= 0)
                    $scope.news.Categories.push(category);
            }
        });
    }
    $scope.send = function () {
        NewsService.add($scope.news).then(function (jsonResult) {
            if (jsonResult.success) {
                $modalInstance.close();
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });

    };
    $scope.remove = function (index) {
        $scope.news.Categories.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});
app.controller('NewsChooseCategoryModalCtrl', function ($scope, $modalInstance, NewsCategoriesService) {

    NewsCategoriesService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.categories = jsonResult.categories;

        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });

    $scope.selectedCategory = null;

    $scope.select = function (category) {
        $scope.selectedCategory = category;
    }
    $scope.cancel = function () {
        $modalInstance.close();
    }
    $scope.confirm = function () {
        $modalInstance.close($scope.selectedCategory);
    }
});
