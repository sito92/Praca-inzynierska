﻿app.factory("NewsService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/News/GetAll'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (news) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/News/Add',
                data: {
                    model: news
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (serviceProvider) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/News/Edit',
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
                url: '/News/Delete',
                data: {
                    id: id
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
