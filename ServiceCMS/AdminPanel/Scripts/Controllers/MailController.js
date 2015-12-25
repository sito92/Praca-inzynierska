app.controller('MailController', function ($scope, $modal) {  
    $scope.composeMail = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Mail/GetModal?name=ComposeMail',
            controller: 'ComposeMailModalCtrl',
            size: "lg"
        });
    };
    $scope.newsletterRecivers = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Mail/GetModal?name=NewsletterRecivers',
            controller: 'NewsletterReciversModalCtrl',
            size: "lg"
        });
    }
});
app.controller('NewsletterReciversModalCtrl', function ($scope, $modalInstance, MailService,$modal) {
    var refresh = function() {
        MailService.getAllNewsletterReceivers().then(function(jsonResult) {
            if (jsonResult.success) {
                $scope.recivers = jsonResult.data;

            } else {
                alert(jsonResult.message);
            }
        }, function() {
            alert("Error");
        });
    }
    refresh();
   

    $scope.add = function() {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Mail/GetModal?name=AddNewsletterReciver',
            controller: 'AddNewsletterReciverModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.edit = function (reciver) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Mail/GetModal?name=EditNewsletterReciver',
            controller: 'EditNewsletterReciverModalCtrl',
            size: "md",
            resolve: {
                reciver:function() {
                    return angular.copy(reciver);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.delete = function (reciver) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Mail/GetModal?name=ConfirmDelete',
            controller: 'DeleteNewsletterReciverModalCtrl',
            size: "sm",
            resolve: {
                reciver: function () {
                    return reciver;
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
    $scope.cancel = function () {
        $modalInstance.close();
    }  
});
app.controller('AddNewsletterReciverModalCtrl', function ($scope, $modalInstance,MailService) {
    $scope.reciver = {
        EmailAdress:''
    };

    $scope.save = function () {

        MailService.addNewsletterReceiver($scope.reciver).then(function (jsonResult) {
            if (jsonResult.success) {
                $modalInstance.close();
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });

    }; 
    
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('EditNewsletterReciverModalCtrl', function ($scope, $modalInstance, MailService,reciver) {
    $scope.reciver = reciver;

    $scope.save = function () {

        MailService.updateNewsletterReceiver($scope.reciver).then(function (jsonResult) {
            if (jsonResult.success) {
                $modalInstance.close();
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });

    };

    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('DeleteNewsletterReciverModalCtrl', function ($scope, $modalInstance, MailService, reciver) {
    $scope.reciver = reciver;
    $scope.confirm = function () {
        MailService.deleteNewsletterReceiver($scope.reciver).then(function (jsonResult) {
            if (jsonResult.success) {
                $modalInstance.close();
            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });

    };
    $scope.decline = function (index) {
        $modalInstance.close();
    }

});
app.controller('ComposeMailModalCtrl', function ($scope, $modalInstance, MailService,$modal,$filter) {
    $scope.mail = {
        Subject: '',
        Content: '',
        Subscribers:[]
    };

    $scope.send = function () {
        MailService.sendMail($scope.mail).then(function (jsonResult) {
            if (jsonResult.success) {
                $modalInstance.close();
            } else {
                alert("Error");
            }
        }, function () {
            alert("Error");
            $modalInstance.dismiss();
        });

    };
    $scope.add = function () {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/Mail/GetModal?name=ChooseReciver',
            controller: 'ChooseReciverModalCtrl',
            size: "md"
        });
        modalInstance.result.then(function (reciver) {
            if (reciver != undefined) {
                var found = $filter('filter')($scope.mail.Subscribers, { EmailAddress: reciver.EmailAddress });
                if (found.length <= 0)
                    $scope.mail.Subscribers.push(reciver);
            }
        });
    }
    $scope.addAll = function () {
        MailService.getAllNewsletterReceivers().then(function (jsonResult) {
            if (jsonResult.success) {
                angular.forEach(jsonResult.data, function(val, key) {
                    var found = $filter('filter')($scope.mail.Subscribers, { EmailAddress: val.EmailAddress });
                    if (found.length <= 0)
                        $scope.mail.Subscribers.push(val)
                });

            } else {
                alert(jsonResult.message);
            }
        }, function () {
            alert("Error");
        });
    }
    $scope.remove = function (index) {
        $scope.mail.Subscribers.splice(index, 1);
    }
    $scope.cancel = function () {
        $modalInstance.dismiss();
    };
});
app.controller('ChooseReciverModalCtrl', function ($scope, $modalInstance, MailService) {

    MailService.getAllNewsletterReceivers().then(function (jsonResult) {
        if (jsonResult.success) {
            $scope.recivers = jsonResult.data;

        } else {
            alert(jsonResult.message);
        }
    }, function () {
        alert("Error");
    });

    $scope.selectedReciver = null;

    $scope.select = function (reciver) {
        $scope.selectedReciver = reciver;
    }
    $scope.cancel = function () {
        $modalInstance.close();
    }
    $scope.confirm = function () {
        $modalInstance.close($scope.selectedReciver);
    }
});