app.service('productService', ['$http', '$q', 'homePageSize', function ($http, $q, homePageSize) {
    var result = {};
    var productsCount = 0;
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
    result.GetProducts = function (pageIndex,fetchAgain) {
        var deferred = $q.defer();
        if (products != null && fetchAgain == undefined) {
            deferred.resolve(products);
        }
        $http({
            method: 'GET',
            url: '/new/api/Product/GetProducts?pageIndex='+pageIndex+'&pageSize='+homePageSize+''
        }).then(function (response) {
            products = response.data.products;
            productsCount = response.data.count;
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
    result.GetProductPages = function () {
        return Math.ceil(productsCount / homePageSize);
    };
    return result;

}]);