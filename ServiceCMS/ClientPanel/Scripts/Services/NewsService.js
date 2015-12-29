app.factory("NewsService", function ($http, $q) {
    return {
        getPaginatedNews: function (amount,page) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/News/GetLatestNews',
                params: {
                    amount: amount,
                    page:page
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getNewsCount: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/News/GetNewsCount'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
