app.factory("RegistratedServicesService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/RegistratedServices/GetAll'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        delete: function (service) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/RegistratedServices/Delete',
                data:
                {
                    id: service.Id
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (service) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/RegistratedServices/Update',
                data:
                {
                    model: service
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
