app.controller('ServicesController', function ($scope, uiCalendarConfig, $compile, ServicesService, ServiceProviderService, $modal) {
    $scope.provider = null;
    $scope.events = [];
    $scope.date = null;
    $scope.result = null;
    ServiceProviderService.getAll().then(function (jsonResult) {
        if (jsonResult.success) {
            
            $scope.providers = jsonResult.data;
            $scope.provider = jsonResult.data[0];
            $scope.refreshEvents($scope.provider, $scope.date.format("DD/MM/YYYY"));
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });
    $scope.providerChange= function() {
        $scope.refreshEvents($scope.provider, $scope.date.format("DD/MM/YYYY"));
    }
    $scope.refreshEvents = function (provider, date) {
        if (provider != null) {
            ServicesService.getProviderServicesAtDate(provider, date).then(function(jsonResult) {
                if (jsonResult.success) {
                    $scope.events.splice(0, $scope.events.length);
                    angular.forEach(jsonResult.data.Events, function(val, key) {
                        $scope.events.push(val);
                    });
                } else {
                    alert(jsonResult.message);
                }
            }, function() {
                alert("Error");
            });
        }
    }

    $scope.dayChange = function (view, element) {
        $scope.date = view.start;
        $scope.refreshEvents($scope.provider, view.start.format("DD/MM/YYYY"));
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
        modalInstance.result.then(function (result) {
            console.log(result);
            $scope.result = result;
            $scope.refreshEvents($scope.provider, $scope.date.format("DD/MM/YYYY"));
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
app.controller('ServiceRegisterModalCtrl', function ($scope, $modalInstance, ServiceTypeService, ServicesService, date, provider) {
    $scope.date = date;
    $scope.registratedService = {};
    $scope.registratedService.StartDate = date.format("DD/MM/YYYY HH:mm:ss");
    $scope.registratedService.ServiceProvider = provider;
    $scope.provider = provider;

    ServiceTypeService.getServiceTypesMatchingTimeCriteria($scope.date.toISOString(), $scope.provider).then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.types = jsonResult.data;
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });
    $scope.send = function () {
        ServicesService.registerService($scope.registratedService).then(function (jsonResult) {
            $modalInstance.close(jsonResult);
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });

    };
    $scope.decline = function () {
        $modalInstance.close();
    }

});