app.factory("PopUpService", function ($http, $q) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/PopUp/GetAll'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        add: function (model) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/PopUp/Add',
                data: {
                    model: model
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        edit: function (model) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/PopUp/Update',
                data: {
                    model: model
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        editList: function (model) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/PopUp/UpdateAll',
                data: {
                    model: model
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        delete: function (id) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/PopUp/Delete',
                data: {
                    id: id
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
