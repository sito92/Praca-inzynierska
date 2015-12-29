app.factory("SettingsService", function ($http, $q) {
    return {
        getByName: function (name) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Settings/GetSettingsByName',
                params: {
                    name:name
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }   
    }
});