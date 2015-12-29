app.controller('NewsController', function ($scope, $modal, NewsService) {
    var refresh = function () {
        $scope.selectedNews = null;
        NewsService.getNewestNewses().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.newses = jsonResult.data;

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }

    refresh();

    $scope.add = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=Add',
            controller: 'NewsAddModalCtrl',
            size: "lg"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.edit = function (news) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=Edit',
            controller: 'NewsEditModalCtrl',
            size: "lg",
            resolve:
            {
                news: function () {
                    return angular.copy(news);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.delete = function (news) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=ConfirmDelete',
            controller: 'NewsDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                news: function () {
                    return angular.copy(news);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.newsCategories = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=NewsCategories',
            controller: 'NewsCategoriesModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.select = function (news) {
        $scope.selectedNews = news;
    }
});
app.controller('NewsAddModalCtrl', function ($scope, $modalInstance, $filter, $modal, NewsService) {
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
            $scope.categories = jsonResult.data;

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
app.controller('NewsEditModalCtrl', function ($scope, $modalInstance, NewsService, news, $modal, $filter) {
    $scope.news = news;

    $scope.save = function () {

        NewsService.edit($scope.news).then(function (jsonResult) {
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
    $scope.remove = function (index) {
        $scope.news.Categories.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('NewsDeleteModalCtrl', function ($scope, $modalInstance, NewsService, news) {
    $scope.news = news;
    $scope.confirm = function () {
        NewsService.delete($scope.news.Id).then(function (jsonResult) {
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
    $scope.decline = function (index) {
        $modalInstance.close();
    }

});
app.controller('NewsCategoriesModalCtrl', function ($scope, $modalInstance, $modal, NewsCategoriesService) {
    var refresh = function () {
        NewsCategoriesService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.categories = jsonResult.data;

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    refresh();


    $scope.add = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=AddCategory',
            controller: 'AddCategoryModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.edit = function (category) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=EditCategory',
            controller: 'EditCategoryModalCtrl',
            size: "md",
            resolve: {
                category: function () {
                    return angular.copy(category);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.delete = function (category) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=ConfirmDelete',
            controller: 'DeleteCategoryModalCtrl',
            size: "sm",
            resolve: {
                category: function () {
                    return category;
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.cancel = function () {
        $modalInstance.close();
    }
});
app.controller('AddCategoryModalCtrl', function ($scope, $modalInstance, NewsCategoriesService) {
    $scope.category = {
        Category: ''
    };

    $scope.save = function () {
        NewsCategoriesService.add($scope.category).then(function (jsonResult) {
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

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('EditCategoryModalCtrl', function ($scope, $modalInstance, NewsCategoriesService,category) {
    $scope.category = category;

    $scope.save = function () {
        NewsCategoriesService.edit($scope.category).then(function (jsonResult) {
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

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});

app.controller('DeleteCategoryModalCtrl', function ($scope, $modalInstance, NewsCategoriesService, category) {
    $scope.category = category;
    $scope.confirm = function () {
        NewsCategoriesService.delete($scope.category).then(function (jsonResult) {
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
    $scope.decline = function (index) {
        $modalInstance.close();
    }

});
