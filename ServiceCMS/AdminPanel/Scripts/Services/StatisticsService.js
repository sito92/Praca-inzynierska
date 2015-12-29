app.factory("StatisticsService", function ($http, $q) {
    return {
        getPage: function (name) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Statistics/GetPage',
                params:{name:name}
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getUsersPerCountry: function () {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Statistics/GetUsersPerCountry'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getUsersForSelectedMonth: function (month,year) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Statistics/GetUsersForSelectedMonth',
                params: {
                    month: month,
                    year:year
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getUsersForEveryMonth: function (year) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Statistics/GetUsersForEveryMonth',
                params: {
                    year: year
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getUsersBetweenDates: function (from,to) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Statistics/GetUsersBetweenDates',
                params: {
                    from: from,
                    to:to
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getUserActionsBetweenDates: function (from, to) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Statistics/GetUserActionsBetweenDates',
                params: {
                    from: from,
                    to: to
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
