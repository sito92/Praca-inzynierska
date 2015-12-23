app.controller('FileController', function ($scope, $modal, FileService) {
    var refresh = function() {
        FileService.getAll().then(function(jsonResult) {
            if (jsonResult.success) {
                $scope.files = jsonResult.data;
            } else {
                alert(jsonResult.message);
            }
        }, function() {
            alert("Error");
        });
    }
    refresh();
    $scope.upload = function ($event) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/File/GetModal?name=Upload',
            controller: 'UploadModalCtrl',
            size: "xlg"
        });
        modalInstance.result.then(function () {
            refresh();
        });
    };
    $scope.delete = function(file) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '/File/GetModal?name=ConfirmDelete',
            controller: 'FileDeleteModalCtrl',
            size: "sm",
            resolve:
            {
                file: function () {
                    return angular.copy(file);
                }
            }
        });
        modalInstance.result.then(function () {
            refresh();
        });
    }
});
app.controller('UploadModalCtrl', function ($scope, $modalInstance, FileUploader) {
    $scope.uploader = new FileUploader();
    $scope.uploader.url = "/File/Upload";
    $scope.uploader.onSuccessItem = function (item, response, status, headers) {
        item.uploadData.Success = response.success;
        item.uploadData.Message = response.message;
    }
    $scope.uploader.onErrorItem = function (item, response, status, headers) {
        console.log("fail");
    }
    $scope.uploader.onBeforeUploadItem = function (item) {
        item.formData.push({ name: item.uploadData.Name });
    }
    $scope.uploader.onAfterAddingFile = function (item) {
        item.uploadData = {
             Name: item.file.name
        };
    }
    $scope.cancel = function () {
        $modalInstance.close();
    };
});
app.controller('FileDeleteModalCtrl', function ($scope, $modalInstance, FileService, file) {
    $scope.file = file;
    $scope.confirm = function () {
        FileService.delete($scope.file).then(function (jsonResult) {
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