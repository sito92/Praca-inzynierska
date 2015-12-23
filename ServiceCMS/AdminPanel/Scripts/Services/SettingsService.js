app.factory("SettingsService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Settings/GetAll'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
