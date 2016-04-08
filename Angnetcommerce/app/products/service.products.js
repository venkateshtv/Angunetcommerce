app.service('productService', ['$http','$q', function ($http,$q) {
    var result = {};
    var products = null;//[{ 'name': 'Honda City', 'price': '250,000' }, { 'name': 'Renault Scala', 'price': '250,000' }, { 'name': 'Nissan Sunny', 'price': '250,000' }, { 'name': 'Honda Jazz', 'price': '250,000' }];
    result.OrderItem = function (selectedProduct,customerid) {
        var deferred = $q.defer();
        $http({
            method: 'POST',
            url: '/new/api/Order/OrderItem',
            data: { stockno: selectedProduct.Stock_No, price: selectedProduct.Price, customerId: customerid }
        }).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        });

        return deferred.promise;
    };
    result.GetProducts = function () {
        var deferred = $q.defer();
        if (products != null) {
            deferred.resolve(products);
        }
        $http({
            method: 'GET',
            url: '/new/api/Product/GetProducts'
        }).then(function (response) {
            products = response.data;
            deferred.resolve(products);
        }, function (error) {
            deferred.reject(error);
        });
        
        return deferred.promise;
    };
    result.GetProduct = function (productId) {
        var product = null;
        for (var i in products) {
            var prod = products[i];
            if (prod.Stock_No == productId) {
                product = prod;
                break;
            }
        }
        return product;
    };
    return result;

}]);