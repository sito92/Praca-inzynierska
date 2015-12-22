app.controller('FileController', function ($scope,$modal) {

    $scope.upload = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/File/GetModal?name=Upload',
            controller: 'UploadModalCtrl',
            size: "lg"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
});
app.controller('UploadModalCtrl', function ($scope, $modalInstance, FileUploader) {
    $scope.uploader = new FileUploader();
    $scope.uploader.url = "/File/Upload";
    $scope.uploader.onSuccessItem = function (item, response, status, headers) {
        console.log("success");
    }
    $scope.uploader.onErrorItem = function (item, response, status, headers) {
        console.log("fail");
    }
    $scope.cancel = function () {
        $modalInstance.dismiss('cancel');
    };
});