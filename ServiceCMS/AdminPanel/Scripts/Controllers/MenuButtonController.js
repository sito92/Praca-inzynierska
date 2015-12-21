app.controller('MenuButtonController', function ($scope, $modal, MenuButtonService) {
    var refresh = function () {
        $scope.selectedNews = null;
        MenuButtonService.getAllRootButtons().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.rootButtons = jsonResult.data;

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }

    refresh();

    //$scope.add = function ($event) {
    //    var modalInstance = $modal.open({
    //        animation: true,
    //        templateUrl: '/News/GetModal?name=Add',
    //        controller: 'NewsAddModalCtrl',
    //        size: "lg"
    //    });
    //    modalInstance.result.then(function () {
    //        refresh();
    //    });
    //};
    $scope.edit = function (button) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=Edit',
            controller: 'MenuButtonEditModalCtrl',
            size: "lg",
            resolve:
            {
                rootButton: function () {
                    return angular.copy(button);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    //$scope.delete = function (news) {
    //    var modalInstance = $modal.open({
    //        animation: true,
    //        templateUrl: '/News/GetModal?name=ConfirmDelete',
    //        controller: 'NewsDeleteModalCtrl',
    //        size: "sm",
    //        resolve:
    //        {
    //            news: function () {
    //                return angular.copy(news);
    //            }
    //        }
    //    });
    //    modalInstance.result.then(function () {
    //        refresh();
    //    });
    //}
    $scope.select = function (button) {
        $scope.selectedButton = button;
    }
});
app.controller('MenuButtonEditModalCtrl', function ($scope, $modalInstance, rootButton,MenuButtonService, $modal, $filter) {
    $scope.rootButton = rootButton;
    $scope.newSubItem = function (scope) {
        var nodeData = scope.$modelValue;
        nodeData.Children.push({
            Content: 'NowyNode',
            Children: []
        });
    };
    $scope.addMainButton = function() {
        $scope.rootButton.Children.push({
            Content: 'NowyNode',
            Children: []
        });
    }
    $scope.toggle = function (scope) {
        scope.toggle();
    };
    $scope.treeOptions = {
        beforeDrop: function(e) {
            return true;
        }
    }
    $scope.list = [
  {
      "id": 1,
      "title": "node1",
      "nodes": [
        {
            "id": 11,
            "title": "node1.1",
            "nodes": [
              {
                  "id": 111,
                  "title": "node1.1.1",
                  "nodes": []
              }
            ]
        },
        {
            "id": 12,
            "title": "node1.2",
            "nodes": []
        }
      ]
  },
  {
      "id": 2,
      "title": "node2",
      "nodrop": true,
      "nodes": [
        {
            "id": 21,
            "title": "node2.1",
            "nodes": []
        },
        {
            "id": 22,
            "title": "node2.2",
            "nodes": []
        }
      ]
  },
  {
      "id": 3,
      "title": "node3",
      "nodes": [
        {
            "id": 31,
            "title": "node3.1",
            "nodes": []
        }
      ]
  }
    ];
    $scope.save = function () {

        MenuButtonService.edit($scope.rootButton).then(function (jsonResult) {
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
    //$scope.add = function () {
    //    var modalInstance = $modal.open({
    //        animation: true,
    //        templateUrl: '/News/GetModal?name=ChooseCategory',
    //        controller: 'NewsChooseCategoryModalCtrl',
    //        size: "md"
    //    });
    //    modalInstance.result.then(function (category) {
    //        if (category != undefined) {
    //            var found = $filter('filter')($scope.news.Categories, { Id: category.Id });
    //            if (found.length <= 0)
    //                $scope.news.Categories.push(category);
    //        }
    //    });
    //}
    //$scope.remove = function (index) {
    //    $scope.news.Categories.splice(index, 1);
    //}
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});