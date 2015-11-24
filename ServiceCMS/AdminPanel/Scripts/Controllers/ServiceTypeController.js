app.controller('ServiceTypeController', function ($scope, $modal) {


    $scope.add = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/ServiceType/GetModal?name=Add',
            controller: 'ServiceTypeAddModalCtrl',
            size: "md"
        });
        modalInstance.rendered.then(function () {

        });
    };
});
app.controller('ServiceTypeAddModalCtrl', function ($scope, $modalInstance) {
    $scope.$watchCollection("serviceType.Phases", function(newV) {
        console.log(newV);

    },true);
    $scope.emptyPhase= {
        Order: 0,
        DelayInSeconds: 0,
        DurationInSeconds: 0,
        Name:''

    }
    $scope.serviceType =
{
    Name: "sdasa",
    Phases: [{}]

}
    $scope.send = function () {

    };
    $scope.add = function(index) {
        $scope.serviceType.Phases.push({});
    }
    $scope.remove = function(index) {
        $scope.serviceType.Phases.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});
