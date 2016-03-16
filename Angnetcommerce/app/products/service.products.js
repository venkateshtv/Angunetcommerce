app.service('productService', ['$http','$q', function ($http,$q) {
    var result = {};
    var products = [{ 'name': 'Honda City', 'price': '250,000' }, { 'name': 'Renault Scala', 'price': '250,000' }, { 'name': 'Nissan Sunny', 'price': '250,000' }, { 'name': 'Honda Jazz', 'price': '250,000' }];
    result.GetProducts = function () {
        var deferred = $q.defer();
        $http({
            method: 'GET',
            url: '/api/Product/GetProducts'
        }).then(function (response) {
            deferred.resolve(response.data);
        }, function (error) {
            deferred.reject(error);
        });
        
        return deferred.promise;
    };

    return result;

}]);