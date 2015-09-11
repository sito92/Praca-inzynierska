app.directive('insetArgument', function ($timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        scope: {
            model: '=ngModel'
        },
        link: function (scope, element, attrs, ngModel) {
                scope.$watch('model', function(newVal,oldVal) {
                    scope.$parent.$parent.arguments[attrs.insetArgument] = newVal;

                });

            
        }
    }

});
