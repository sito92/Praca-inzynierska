app.factory("PopupService", function ($http, $q) {
    return {
        getActive: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/PopUp/GetActivePopUp',
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
