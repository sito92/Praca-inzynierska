﻿app.factory("PageService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Page/GetAll',
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (page) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Page/Insert',
                data: {
                    model: page
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (page) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Page/Update',
                data: {
                    model: page
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
    }
});
