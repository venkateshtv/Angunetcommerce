app.controller('HomeCtrl', ['$scope','productService','$http', function ($scope,productService,$http) {
    $scope.products = [];
    function Init() {
        productService.GetProducts().then(function (response) {
            $scope.products = response;
            console.log('Response', response);
        }, function (error) {
            console.log('error', error);
        });
    };
    Init();
    var formdata = new FormData();
    $scope.getTheFiles = function ($files) {
        angular.forEach($files, function (value, key) {
            formdata.append(key, value);
        });
    };
     // NOW UPLOAD THE FILES.
            $scope.uploadFiles = function () {

                var request = {
                    method: 'POST',
                    url: '/api/product/UploadFiles',
                    data: formdata,
                    headers: {
                        'Content-Type': undefined
                    }
                };

                // SEND THE FILES.
                $http(request)
                    .success(function (d) {
                        alert(d);
                    })
                    .error(function () {
                    });
            }
}]);
