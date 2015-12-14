app.controller('ServicesController', function ($scope, uiCalendarConfig, $compile, ServicesService) {
    $scope.events = [];  
    $scope.refreshEvents = function(provider,date) {
        ServicesService.getProviderServicesAtDate(provider,date).then(function (jsonResult) {
            if (jsonResult.success) {
                //$scope.events = jsonResult.data.Events;
                var date = new Date();
                var d = date.getDate();
                var m = date.getMonth();
                var y = date.getFullYear();
                $scope.events2 = [
                  { title: 'Birthday Party', start: new Date(y, m, d, 12, 0), end: new Date(y, m, d, 13, 30), allDay: false, editable: false },
                  { title: 'Click for Google', start: new Date(y, m, 28), end: new Date(y, m, 29), url: 'http://google.com/' }
                ];
                $scope.events.slice(0, $scope.events.length);

                angular.forEach(jsonResult.data.Events, function (val, key) {
                    $scope.events.push(val);
                });

                //uiCalendarConfig.calendars.serviceCalendar.fullCalendar('render');

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();
    $scope.timeClick = function (date, jsEvent, view, resourceObj) {
        console.log(date);
        console.log(jsEvent);
        console.log(view);
        console.log(resourceObj);
    }

    //$scope.events = [    
    //  { title: 'Birthday Party', start: new Date(y, m, d, 12, 0), end: new Date(y, m, d, 13, 30), allDay: false,editable:false },
    //  { title: 'Click for Google', start: new Date(y, m, 28), end: new Date(y, m, 29), url: 'http://google.com/' }
    //];


    $scope.eventRender = function (event, element, view) {
        element.attr({
            'tooltip': event.title,
            'tooltip-append-to-body': true
        });
        $compile(element)($scope);
    };
    $scope.eventClick = function (event, jsEvent, view) {
        console.log(event);
    }
    $scope.dayChange = function (view, element) {
        $scope.refreshEvents(null, view.start.format("MM/DD/YYYY HH:MM:ss"));
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
                agenda: 'H:mm'
            },
            height: 450,
            editable: true,
            header: {
                left: 'title',
                center: '',
                right: 'today prev,next'
            },
            eventClick:$scope.eventClick,
            viewRender: $scope.dayChange
        }

    };
   
    
    /* event sources array*/
    $scope.eventSources = [$scope.events];
    $scope.eventSources2 = [$scope.calEventsExt, $scope.eventsF, $scope.events];
});