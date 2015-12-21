app.factory("MenuButtonService", function ($http, $q) {
    return {
        getAllRootButtons: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/MenuButton/GetAllRootButtons'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (button) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/MenuButton/Edit',
                data: {
                    model: button
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (button) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/MenuButton/Add',
                data: {
                    model: button
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        delete: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/MenuButton/Delete',
                data: {
                    id: id
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
