app.controller('InsetAddModalCtrl', function ($scope, $modalInstance, $rootScope, InsetService, $compile) {

    $scope.arguments = {};
    InsetService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.avaiableInsets = jsonResult.data;
        }
    }, function () {
        alert("Error");
        $modalInstance.dismiss('cancel');;
    });
    $scope.send = function () {
        InsetService.validate($scope.insetString()).then(function (jsonResult) {
            if (jsonResult.success) {
               // $rootScope.$broadcast(customEvents.addedInset, $scope.insetString());
                $modalInstance.close();
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss('cancel');;
        });


    };
    $scope.changeInsetType = function () {
        $scope.arguments = {};
        $scope.processing = true;
        InsetService.getInsetPart($scope.choosedInset.Name).then(function (jsonResult) {
            var html = $.parseHTML(jsonResult);
            $("#insetPartContainer").html($compile(html)($scope));

        }, function () {
            alert("Error");
            $modalInstance.dismiss('cancel');;
        });
        $scope.processing = false;
    };
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');;
    };

    $scope.insetString = function () {
        if ($scope.choosedInset != null) {
            var result = "[" + $scope.choosedInset.Name;
            angular.forEach($scope.arguments, function (val, key) {
                result += ";";
                result += key + "=" + "\"" + val + "\"";
            });
            return result + "]";
        }
        return null;
    }
});