app.controller('PageController', function ($scope, $modal, PageService) {
    var refresh = function () {
        PageService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.pages = jsonResult.data;

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
            templateUrl: '/Page/GetModal?name=Add',
            controller: 'PageAddModalCtrl',
            size: "lg"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.edit = function (page) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Page/GetModal?name=Edit',
            controller: 'PageEditModalCtrl',
            size: "lg",
            resolve:
            {
                page: function () {
                    return angular.copy(page);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.delete = function (page) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Page/GetModal?name=ConfirmDelete',
            controller: 'PageDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                page: function () {
                    return angular.copy(page);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.select = function (news) {
        $scope.selectedNews = news;
    }
});
app.controller('PageAddModalCtrl', function ($scope, $modalInstance, $filter, $modal, PageService) {
    $scope.page =
{
    Name: "",
    Content: "",
    Media:[]
}

    $scope.send = function () {
        PageService.add($scope.page).then(function (jsonResult) {
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
            templateUrl: '/Page/GetModal?name=ChooseFile',
            controller: 'PageChooseFileModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (file) {
            if (file != undefined) {
                var found = $filter('filter')($scope.page.Media, { Id: file.Id });
                if (found.length <= 0)
                    $scope.page.Media.push(file);
            }
        });
    }
    $scope.remove = function (index) {
        $scope.page.Media.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('PageEditModalCtrl', function ($scope, $modalInstance, PageService, page, $modal, $filter) {
    $scope.page = page;

    $scope.save = function () {

        PageService.edit($scope.page).then(function (jsonResult) {
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
            templateUrl: '/Page/GetModal?name=ChooseFile',
            controller: 'PageChooseFileModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (file) {
            if (file != undefined) {
                var found = $filter('filter')($scope.page.Media, { Id: file.Id });
                if (found.length <= 0)
                    $scope.page.Media.push(file);
            }
        });
    }
    $scope.remove = function (index) {
        $scope.page.Media.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('PageDeleteModalCtrl', function ($scope, $modalInstance, PageService, page) {
    $scope.page = page;
    $scope.confirm = function () {
        PageService.delete($scope.page.Id).then(function (jsonResult) {
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
app.controller('PageChooseFileModalCtrl', function ($scope, $modalInstance, FileService) {

    FileService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.files = jsonResult.data;

        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });

    $scope.selectedFile = null;

    $scope.select = function (file) {
        $scope.selectedFile = file;
    }
    $scope.cancel = function () {
        $modalInstance.close();
    }
    $scope.confirm = function () {
        $modalInstance.close($scope.selectedFile);
    }
});

