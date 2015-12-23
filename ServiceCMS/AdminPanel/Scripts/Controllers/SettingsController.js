app.controller('SettingsController', function ($scope,SettingsService){
    var refresh = function () {
        SettingsService.getAll().then(function (jsonResult) {
            if (jsonResult.success) {
                var model = jsonResult.data;
                angular.forEach(model.Settings, function (val, key) {
                    if(val.InputType=="checkbox")
                    model.Settings[key].Value = $.parseJSON(val.Value);
                });
                $scope.model = model;
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    refresh();
});