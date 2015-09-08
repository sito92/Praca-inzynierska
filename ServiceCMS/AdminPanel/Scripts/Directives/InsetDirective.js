app.directive('ngInset', function ($timeout) {

    var template = "<div class='btn btn-default btn-sm' ng-click='open()'>wstawka</div>";
    var setCursorPsoition = function (elem, caretPos) {
        if (elem != null) {
            if (elem.createTextRange) {
                var range = elem.createTextRange();
                range.move('character', caretPos);
                range.select();
            } else {
                if (elem.selectionStart) {
                    elem.focus();
                    elem.setSelectionRange(caretPos, caretPos);
                } else
                    elem.focus();
            }
        }
    };
    var insertText = function (elem, model, val) {
        var domElement = elem[0];
        if (domElement.selectionStart || domElement.selectionStart === 0) {
            var startPos = domElement.selectionStart;
            var endPos = domElement.selectionEnd;
            model = model.substring(0, startPos) + val + model.substring(endPos, model.length);
            return model;
        }
    };
    var linkFunction = function (scope, elem, attrs, ngModelCtrl) {
        scope.$on(customEvents.addedInset, function (e, inset) {
            var selectionStart = elem[0].selectionStart;
            var updatedVal = insertText(elem, ngModelCtrl.$viewValue, inset);
            $timeout(function () {
             
                setCursorPsoition(elem[0], selectionStart+inset.length);
            });
            ngModelCtrl.$setViewValue(updatedVal);
            ngModelCtrl.$render();
        });
    };
    return {

        restrict: 'A',
        require: '^ngModel',
        //scope: {
        //    ngModel:'='
        //},
        controller: ['$scope', '$modal', function ($scope, $modal) {

            $scope.open = function () {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '/Inset/GetModal?name=Add',
                    controller: 'InsetAddModalCtrl',
                    size: "sm"
                });
                modalInstance.rendered.then(function () {
                });
            }
        }],
        compile: function (tElement, tAttributes) {
            var button = $(template);
            tElement.after(button);
            return linkFunction;
        }
    }

});
app.controller('InsetAddModalCtrl', function ($scope, $modalInstance, $rootScope) {

    $scope.send = function () {
        $scope.insetString = "[osiem]";
        $rootScope.$broadcast(customEvents.addedInset, $scope.insetString);
        $modalInstance.close();
    };

    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');;
    };
});