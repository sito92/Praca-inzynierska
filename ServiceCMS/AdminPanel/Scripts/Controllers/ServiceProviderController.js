app.controller('ServiceProviderController', function ($scope, $modal, ServiceProviderService) {
    var refresh = function () {
        $scope.selectedProvider = null;
        ServiceProviderService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.providers = jsonResult.data;

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
            templateUrl: '/ServiceProvider/GetModal?name=Add',
            controller: 'ServiceProviderAddModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.edit = function (provider) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceProvider/GetModal?name=Edit',
            controller: 'ServiceProviderEditModalCtrl',
            size: "md",
            resolve:
            {
                provider: function () {
                    return angular.copy(provider);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.delete = function (provider) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceProvider/GetModal?name=ConfirmDelete',
            controller: 'ServiceProviderDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                provider: function () {
                    return angular.copy(provider);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.selectedProvider = null;

    $scope.select = function (provider) {
        $scope.selectedProvider = provider;
    }
});
app.controller('ServiceProviderAddModalCtrl', function ($scope, $modalInstance, ServiceProviderService,$modal,$filter) {
    $scope.provider =
    {
        Name: "",
        AvailableServices: [       
        ]
    }
    $scope.send = function () {      
        ServiceProviderService.add($scope.provider).then(function (jsonResult) {
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
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceProvider/GetModal?name=ChooseType',
            controller: 'ServiceProviderChooseModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (type) {
            if (type != undefined) {
                var found = $filter('filter')($scope.provider.AvailableServices, { Id: type.Id });
                if(found.length<=0)
                $scope.provider.AvailableServices.push(type);
            }
        });
    }
    $scope.remove = function (index) {
        $scope.provider.AvailableServices.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('ServiceProviderEditModalCtrl', function ($scope, $modalInstance, ServiceProviderService, $modal, $filter,provider) {
    $scope.provider = provider;

    $scope.send = function () {
        ServiceProviderService.edit($scope.provider).then(function (jsonResult) {
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
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceProvider/GetModal?name=ChooseType',
            controller: 'ServiceProviderChooseModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (type) {
            if (type != undefined) {
                var found = $filter('filter')($scope.provider.AvailableServices, { Id: type.Id });
                if (found.length <= 0)
                    $scope.provider.AvailableServices.push(type);
            }
        });
    }
    $scope.remove = function (index) {
        $scope.provider.AvailableServices.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('ServiceProviderDeleteModalCtrl', function ($scope, $modalInstance, ServiceProviderService, provider) {
    $scope.provider = provider;
    $scope.confirm = function () {
        ServiceProviderService.delete($scope.provider.Id).then(function (jsonResult) {
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
app.controller('ServiceProviderChooseModalCtrl', function ($scope, $modalInstance, ServiceTypeService) {
    ServiceTypeService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.types = jsonResult.data;

        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });

    $scope.selectedType = null;

    $scope.select = function(type) {
        $scope.selectedType = type;
    }
    $scope.cancel = function() {
        $modalInstance.close();
    }
    $scope.confirm = function() {
        $modalInstance.close($scope.selectedType);
    }
});