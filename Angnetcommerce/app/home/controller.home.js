app.controller('HomeCtrl', ['$scope','productService', function ($scope,productService) {
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

}]);
