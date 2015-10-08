app.factory("FileService", function ($http, $q) {
    return {
        getAllImages: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/File/GetAllImages'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
