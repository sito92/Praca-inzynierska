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
    $scope.edit = function (type) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceProvider/GetModal?name=Edit',
            controller: 'ServiceProviderEditModalCtrl',
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
    $scope.delete = function (type) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceProvider/GetModal?name=ConfirmDelete',
            controller: 'ServiceProviderDeleteModalCtrl',
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
    $scope.selectedProvider = null;

    $scope.select = function (provider) {
        $scope.selectedProvider = provider;
    }
});