app.controller('ServicesController', function ($scope, uiCalendarConfig, $compile, ServicesService, ServiceProviderService, $modal) {
    $scope.provider = null;
    $scope.events = [];
    ServiceProviderService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.providers = jsonResult.data;
            $scope.provider = jsonResult.data[0];
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });

    $scope.refreshEvents = function(provider,date) {
        ServicesService.getProviderServicesAtDate(provider,date).then(function (jsonResult) {
            if (jsonResult.success) {                
                $scope.events.slice(0, $scope.events.length);
                angular.forEach(jsonResult.data.Events, function (val, key) {
                    $scope.events.push(val);
                });                
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }

    $scope.dayChange = function (view, element) {
        $scope.refreshEvents($scope.provider, view.start.format("MM/DD/YYYY HH:mm:ss"));
    }
    $scope.slotClick = function (date, jsEvent, view) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Services/GetModal?name=Register',
            controller: 'ServiceRegisterModalCtrl',
            size: "md",
            resolve:
            {
                date:function() {
                    return date;
                },
                provider:function() {
                    return $scope.provider;
                }
            }
        });
    }

    $scope.uiConfig = {
        calendar: {
            defaultView: 'agendaDay',
            allDaySlot: false,
            slotDuration: '00:10:00',
            minTime: '08:00:00',
            maxTime: '18:00:00',
            axisFormat: 'HH:mm',
            timeFormat: {
                agenda: 'HH:mm'
            },
            height: 450,
            editable: true,
            header: {
                left: 'title',
                center: '',
                right: 'today prev,next'
            },
            eventClick:$scope.eventClick,
            viewRender: $scope.dayChange,
            dayClick:$scope.slotClick
        }

    };
   
    $scope.eventSources = [$scope.events];
});
app.controller('ServiceRegisterModalCtrl', function ($scope, $modalInstance, date,provider) {
    $scope.date = date;
    $scope.provider = provider;
    $scope.decline = function () {
        $modalInstance.close();
    }

});