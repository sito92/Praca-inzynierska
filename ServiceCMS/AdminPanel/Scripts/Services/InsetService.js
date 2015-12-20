app.factory("InsetService", function ($http, $q,$modal) {
    return {
        getAll: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Inset/GetAll',
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getInsetPart: function (name) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Inset/GetInsetPart',
                params: {
                    name: name
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
        ,
        validate: function (inset) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Inset/Validate',
                params: {
                    inset: inset
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getInset: function () {
            var deferred = $q.defer();
            var modalInstance = $modal.open({
                animation: true,
                templateUrl: '/Inset/GetModal?name=Add',
                controller: 'InsetAddModalCtrl',
            });

            modalInstance.result.then(function (inset) {
                if (inset) {
                    deferred.resolve(inset);
                } else {
                    deferred.reject();
                }
            }, deferred.reject);
            return deferred.promise;

        }
    }
});
