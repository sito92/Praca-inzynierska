app.controller('PopUpController', function ($scope, $modal, PopUpService) {
    var refresh = function () {
        $scope.selectedNews = null;
        PopUpService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.model = jsonResult.data;

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }

    refresh();
    $scope.activatePopUp = function (popUp, event) {
        angular.forEach($scope.model.PopUps, function (val, key) {
            if (val.Id == popUp.Id) {
                val.Active = val.Active;
            }
            else {
                val.Active = false;
            }

        });
    }
    $scope.save = function () {
        PopUpService.editList($scope.model).then(function (jsonResult) {
            if (jsonResult.success) {
                refresh();

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    $scope.add = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/PopUp/GetModal?name=Add',
            controller: 'PopUpAddModalCtrl',
            size: "lg"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.edit = function (popUp) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/PopUp/GetModal?name=Edit',
            controller: 'PopUpEditModalCtrl',
            size: "lg",
            resolve:
            {
                popUp: function () {
                    return angular.copy(popUp);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.delete = function (popUp) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/PopUp/GetModal?name=ConfirmDelete',
            controller: 'PopUpDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                popUp: function () {
                    return angular.copy(popUp);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }

});
app.controller('PopUpEditModalCtrl', function ($scope, $modalInstance, PopUpService, popUp) {
    $scope.popUp = popUp;

    $scope.save = function () {

        PopUpService.edit($scope.popUp).then(function (jsonResult) {
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
app.controller('PopUpDeleteModalCtrl', function ($scope, $modalInstance, PopUpService, popUp) {
    $scope.popUp = popUp;
    $scope.confirm = function () {
        PopUpService.delete($scope.popUp.Id).then(function (jsonResult) {
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
app.controller('PopUpAddModalCtrl', function ($scope, $modalInstance, PopUpService) {
    $scope.popUp =
{
    Tilte: "",
    Content: "",
    Active: false
}

  
    $scope.send = function () {
        PopUpService.add($scope.popUp).then(function (jsonResult) {
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
        $modalInstance.dismiss('cancel');
    };
});




