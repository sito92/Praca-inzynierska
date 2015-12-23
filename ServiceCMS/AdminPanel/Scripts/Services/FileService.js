﻿app.factory("FileService", function ($http, $q) {
    return {
        getAllImages: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/File/GetAllFiles',
                params:
                {
                    fileType:1
                }
                    
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/File/GetAllFiles',
                params:
                {
                    fileType: 0
                }

            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        delete: function (file) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/File/Delete',
                data:
                {
                    id: file.Id
                }

            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
