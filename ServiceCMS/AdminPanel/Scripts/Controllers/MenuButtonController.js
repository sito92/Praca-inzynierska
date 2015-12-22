﻿app.controller('MenuButtonController', function ($scope, $modal, MenuButtonService) {
    var refresh = function () {
        $scope.selectedButton = null;
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
    $scope.add = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=AddNode',
            controller: 'AddButtonModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (node) {
            refresh();
        });
    }
    $scope.delete = function (button) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=ConfirmDelete',
            controller: 'ConfirmDeleteModalCtrl',
            size: "sm",
            resolve:
           {
               rootButton: function () {
                   return angular.copy(button);
               }
           }
        });
        modalInstance.result.then(function (node) {
            refresh();
        });
    }
    $scope.select = function (button) {
        $scope.selectedButton = button;
    }
});
app.controller('MenuButtonEditModalCtrl', function ($scope, $modalInstance, rootButton,MenuButtonService, $modal, $filter) {
    $scope.rootButton = rootButton;
    $scope.addMainButton = function() {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=AddNode',
            controller: 'AddNodeModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (node) {
            $scope.rootButton.Children.push(node);
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
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
    $scope.editNode = function (node) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=EditNode',
            controller: 'EditNodeModalCtrl',
            size: "md",
            resolve: {
                button:function() {
                    return node;
                }
            }
        });
    }
    $scope.addNode = function (scope) {
        var button = scope.$modelValue;
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=AddNode',
            controller: 'AddNodeModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (node) {
            button.Children.push(node);
        });
    }
});
app.controller('EditNodeModalCtrl', function ($scope, $modalInstance, button,$modal) {

    $scope.choosePage = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=ChoosePage',
            controller: 'ChoosePageModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (page) {
            $scope.button.Page = page;
        });
    }
    $scope.deletePage = function () {
        $scope.button.Page = null;
    }
    $scope.button = button;

    $scope.cancel = function () {
        $modalInstance.dismiss();
    }
});
app.controller('AddNodeModalCtrl', function ($scope, $modalInstance,$modal) {

    $scope.button = {
        Content: '',
        Page:null,
        Children:[]
    }
    $scope.choosePage = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=ChoosePage',
            controller: 'ChoosePageModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (page) {
            $scope.button.Page = page;
        });
    }
    $scope.deletePage = function () {
        $scope.button.Page = null;
    }
    $scope.add = function() {
        $modalInstance.close($scope.button);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    }
});
app.controller('ChoosePageModalCtrl', function ($scope, $modalInstance,PageService) {
    PageService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.pages = jsonResult.data;

        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });
    $scope.selectedPage = null;

    $scope.select = function (page) {
        $scope.selectedPage = page;
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    }
    $scope.confirm = function () {
        $modalInstance.close($scope.selectedPage);
    }
});
app.controller('AddButtonModalCtrl', function ($scope, $modalInstance, $modal, MenuButtonService) {

    $scope.button = {
        Content: '',
        Page: null,
        Children: []
    }
    $scope.choosePage = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/MenuButton/GetModal?name=ChoosePage',
            controller: 'ChoosePageModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (page) {
            $scope.button.Page = page;
        });
    }
    $scope.deletePage = function () {
        $scope.button.Page = null;
    }
    $scope.add = function () {
        MenuButtonService.add($scope.button).then(function (jsonResult) {
            if (jsonResult.success) {
                $modalInstance.close();
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    }
});
app.controller('ConfirmDeleteModalCtrl', function ($scope, $modalInstance, MenuButtonService, rootButton) {
    $scope.rootButton = rootButton;
    $scope.confirm = function () {
        MenuButtonService.delete($scope.rootButton.Id).then(function (jsonResult) {
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