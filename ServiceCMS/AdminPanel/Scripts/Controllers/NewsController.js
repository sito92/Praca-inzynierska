app.controller('NewsController', function ($scope, $modal) {
    $scope.add = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/News/GetModal?name=Add',
            controller: 'AddModalCtrl',
            size: "lg"
        });
        modalInstance.rendered.then(function () {
            
        });
    };
});
app.controller('AddModalCtrl', function ($scope, $modalInstance) {
   
    $scope.send = function () {
      
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});
