app.controller('ServiceTypeController', function ($scope, $modal, ServiceTypeService) {
    var refresh = function () {
        $scope.selectedType = null;
        ServiceTypeService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.serviceTypes = jsonResult.data;

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
            templateUrl: '/ServiceType/GetModal?name=Add',
            controller: 'ServiceTypeAddModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.edit = function (type) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceType/GetModal?name=Edit',
            controller: 'ServiceTypeEditModalCtrl',
            size: "md",
            resolve:
            {
                type: function () {
                    return angular.copy(type);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.delete = function(type) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceType/GetModal?name=ConfirmDelete',
            controller: 'ServiceTypeDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                type: function () {
                    return angular.copy(type);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.selectedType = null;

    $scope.select = function (type) {
        $scope.selectedType = type;
    }
});
app.controller('ServiceTypeAddModalCtrl', function ($scope, $modalInstance, ServiceTypeService) {
    $scope.serviceType =
    {
        Name: "",
        Phases: [
                    {}
        ]
    }
    $scope.send = function () {
        angular.forEach($scope.serviceType.Phases, function (value, key) {
            value.Order = key;
        });

        ServiceTypeService.add($scope.serviceType).then(function (jsonResult) {
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
    $scope.add = function (index) {
        $scope.serviceType.Phases.splice(index + 1, 0, {});
    }
    $scope.remove = function (index) {
        $scope.serviceType.Phases.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('ServiceTypeEditModalCtrl', function ($scope, $modalInstance, ServiceTypeService, type) {
    $scope.serviceType = type;
   
    $scope.save = function () {
        angular.forEach($scope.serviceType.Phases, function (value, key) {
            value.Order = key;
        });

        ServiceTypeService.edit($scope.serviceType).then(function (jsonResult) {
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
    $scope.add = function (index) {
        $scope.serviceType.Phases.splice(index + 1, 0, {});
    }
    $scope.remove = function (index) {
        $scope.serviceType.Phases.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('ServiceTypeDeleteModalCtrl', function ($scope, $modalInstance, ServiceTypeService, type) {
    $scope.serviceType = type;
    $scope.confirm = function () {     
        ServiceTypeService.delete($scope.serviceType.Id).then(function (jsonResult) {
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

