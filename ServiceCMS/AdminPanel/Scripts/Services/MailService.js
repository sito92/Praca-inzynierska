app.factory("MailService", function ($http, $q) {
    return {
        addNewsletterReceiver: function (reciver) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Mail/AddNewsletterReceiver',
                data:
                {
                    model: reciver
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        updateNewsletterReceiver: function (reciver) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Mail/UpdateNewsletterReceiver',
                data:
                {
                    model: reciver
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        deleteNewsletterReceiver: function (reciver) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Mail/DeleteNewsletterReceiver',
                data:
                {
                    model: reciver
                }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        getAllNewsletterReceivers: function (reciver) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: '/Mail/GetAllNewsletterReceivers'
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },
        sendMail: function (model) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: '/Mail/SendMail',
                data:
              {
                  model: model
              }
            }).success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    }
});
