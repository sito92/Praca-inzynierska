app.factory("ServicesService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Services/GetAll'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        registerService: function (service) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Services/RegisterService',
                data: {
                    model: service
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getProviderServicesAtDate: function (provider, date) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Services/GetProviderServicesAtDate',
                data:
                {
                    provider:provider,
                    date: date
                }
                    
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
