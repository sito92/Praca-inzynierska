app.factory("NewsCategoriesService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/News/GetAllCategories'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (category) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/News/AddCategory',
                data:
                {
                    model:category
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (category) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/News/EditCategory',
                data:
                {
                    model: category
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        delete: function (category) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/News/DeleteCategory',
                data:
                {
                    id: category.Id
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
