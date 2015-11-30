app.controller('ServiceTypeController', function ($scope, $modal, ServiceTypeService) {
    var refresh = function () {
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
    $scope.edit = function (index) {
        var type = $scope.serviceTypes[index];
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
