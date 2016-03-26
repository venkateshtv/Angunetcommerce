app.controller('ProductDetailCtrl', ['$scope', '$stateParams', 'productService', function ($scope, $stateParams, productService) {
    $scope.product = null;
    function Init() {
        if ($stateParams.Stock_No == undefined) {
            return;
        }

        $scope.product = productService.GetProduct($stateParams.Stock_No);
        if ($scope.product == null) {
            return;
        }
    };
    Init();



}]);