app.controller('RegistratedServicesController', function ($scope, RegistratedServicesService,$modal) {
    var refresh = function () {
        RegistratedServicesService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                $scope.services = jsonResult.data;
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    refresh();

    $scope.dynamicPopover = {
        templateUrl: 'myPopoverTemplate.html',
    }
    $scope.delete = function (service) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/RegistratedServices/GetModal?name=ConfirmDelete',
            controller: 'RegistratedServicesDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                service: function () {
                    return angular.copy(service);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
});
app.controller('RegistratedServicesDeleteModalCtrl', function ($scope, $modalInstance, RegistratedServicesService, service) {
    $scope.service = service;
    $scope.confirm = function () {
        RegistratedServicesService.delete($scope.service).then(function (jsonResult) {
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