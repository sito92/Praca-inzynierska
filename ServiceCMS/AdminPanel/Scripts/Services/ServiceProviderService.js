app.factory("ServiceProviderService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/ServiceProvider/GetAll'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (serviceProvider) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/ServiceProvider/Add',
                data: {
                    model: serviceProvider
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (serviceProvider) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/ServiceProvider/Edit',
                data: {
                    model: serviceProvider
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        delete: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/ServiceProvider/Delete',
                data: {
                    id: id
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
