app.factory("MenuService", function ($http, $q) {
    return {
        getMenuData: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Menu/GetMenuData',
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
