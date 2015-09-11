app.factory("PageService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Page/GetAll',
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
