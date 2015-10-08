app.directive('imagesPicker', function ($compile) {
    var linkFunction = function (scope, elem, attrs, ngModelCtrl) {
        var fn = $compile(elem);
        fn(scope);

        scope.$watch('model', function (newVal, oldVal) {
            scope.$parent.$parent.arguments[attrs.imagesPicker] = newVal;
        });
    };
    return {
        restrict: 'A',
        require: 'ngModel',
        scope: {
            model: '=ngModel'
        },
        controller: ['$scope', '$modal', function ($scope, $modal) {
            $scope.$on(customEvents.choosedImages, function (e, images) {
                $scope.imagesNames = images.map(function (image) { return image.Name; }).join(', ');
                $scope.model = images.map(function (image) { return image.Id; }).join(',');
            });

            $scope.open = function () {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/Picker/GetModal?name=Images',
                    controller: 'ImagesPickerController'

                });
                modalInstance.rendered.then(function () {
                });
            }
        }],
        compile: function (tElement, tAttributes) {

            tElement.removeAttr('images-picker');
            tElement.attr("ng-click", "open()");
            return linkFunction;
           
        }
    }
});
app.controller('ImagesPickerController', function ($scope, $modalInstance, FileService, $rootScope) {
    $scope.choosedImages = [];
    $scope.ids = [];
    FileService.getAllImages().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.avaiableImages = jsonResult.data;
        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
        $modalInstance.dismiss('cancel');;
    });

    $scope.chooseImage = function (image) {

        var id = $scope.choosedImages.indexOf(image);
        if (id > -1)         
        $scope.choosedImages.splice(id,1);
        else {
            $scope.choosedImages.push(image);
        }
    $scope.contains = function(image) {
        return $scope.choosedImages.indexOf(image) > -1;
    }

    }
    $scope.apply = function () {
        $rootScope.$broadcast(customEvents.choosedImages, $scope.choosedImages);
        $modalInstance.dismiss('cancel');
    
    };
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };

});