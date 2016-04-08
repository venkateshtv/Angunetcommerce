app.controller('ProductDetailCtrl', ['$scope', '$stateParams', 'productService','$state', function ($scope, $stateParams, productService,$state) {
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
    $scope.BuyItem = function () {
        productService.OrderItem($scope.product,1).then(function (response) {
            console.log('Response', response);
            alert('You have bought the car successfully');
            $state.go('home');
        }, function (error) {
            console.log('error', error);
        });
    };


}]);