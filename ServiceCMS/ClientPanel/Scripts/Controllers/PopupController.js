app.controller('PopupController', function ($scope, PopupService, $modal,$timeout) {
   

    var show = function () {
        console.log($scope.showPopup);
        if ($scope.showPopup) {
            PopupService.getActive().then(function(jsonResult) {
                if (jsonResult.success) {
                    $scope.popUp = jsonResult.data;
                    var modalInstance = $modal.open({
                        animation: true,
                        templateUrl: '/PopUp/GetModal?name=Show',
                        controller: 'ShowPopUpModalCtrl',
                        size: "md",
                        resolve:
                        {
                            popUp: function() {
                                return $scope.popUp;
                            }
                        }
                    });
                }
            }, function() {
                alert("Error");
            });
        }
    }
    $timeout(show);
});
app.controller('ShowPopUpModalCtrl', function ($scope, $modalInstance, popUp) {
    $scope.popUp = popUp;
    $scope.decline = function () {
        $modalInstance.close();
    }

});
