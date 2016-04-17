app.controller('HomeCtrl', ['$scope','productService','$http', '$stateParams',function ($scope,productService,$http,$stateParams) {
    $scope.products = [];
    $scope.pageCount = [];
    $scope.currentPage = 0;
    $scope.showNext = false;
    $scope.showPrevious = false;
    var updatePagination = function () {
        $scope.showNext = $scope.currentPage != $scope.pageCount.length;
        $scope.showPrevious = $scope.currentPage != 1;
    };
    $scope.loadProducts = function (pageIndex) {
        productService.GetProducts(pageIndex,true).then(function (response) {
            $scope.products = response;
            $scope.pageCount = new Array(productService.GetProductPages());
            updatePagination();
        }, function (error) {
            console.log('error', error);
        });
    };
    function Init() {
        $scope.currentPage = $stateParams.page === undefined || $stateParams.page == null ? 1 : parseInt($stateParams.page);
        $scope.loadProducts($scope.currentPage-1);
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
