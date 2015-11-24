app.factory("ServiceTypeService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/ServiceType/GetAll',
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (serviceType) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/ServiceType/Add',
                data: {
                    model: serviceType
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
