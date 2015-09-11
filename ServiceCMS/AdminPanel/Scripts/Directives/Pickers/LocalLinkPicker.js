app.directive('localLinkPicker', function ($compile) {
    var linkFunction = function (scope, elem, attrs, ngModelCtrl) {
        var fn = $compile(elem);
        fn(scope);

        scope.$watch('model', function (newVal, oldVal) {
            scope.$parent.$parent.arguments[attrs.localLinkPicker] = newVal;
        });
    };
    return {
        restrict: 'A',
        require: 'ngModel', 
        scope: {
            model: '=ngModel'
        },
        controller: ['$scope', '$modal', function ($scope, $modal) {
            $scope.$on(customEvents.choosedPage, function (e, page) {
                $scope.url = page.Name;
                $scope.model = page.Id;
            });          
            $scope.open = function () {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/Picker/GetModal?name=LocalLink',
                    controller: 'LocalLinkPickerController'
                    
                });
                modalInstance.rendered.then(function () {
                });
            }
        }],
        compile: function (tElement, tAttributes) {
            
            tElement.removeAttr('local-link-picker');
            tElement.attr("ng-click", "open()");
            return linkFunction;
            var fn = $compile(tElement);
            return function (scope) {
                fn(scope);
            };
        }        
    }
});
app.controller('LocalLinkPickerController', function ($scope, $modalInstance, PageService, $rootScope) {
    PageService.getAll().then(function(jsonResult) {
        if (jsonResult.success) {
            $scope.avaiablePages = jsonResult.data;
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
        $modalInstance.dismiss('cancel');;
    });
    $scope.choosePage = function (page) {
        $rootScope.$broadcast(customEvents.choosedPage,page);
            $modalInstance.dismiss('cancel');
        }
        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

});