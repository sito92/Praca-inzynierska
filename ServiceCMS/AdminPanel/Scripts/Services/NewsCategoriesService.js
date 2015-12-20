app.factory("NewsCategoriesService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/News/GetAllCategories'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }      
    }
});
