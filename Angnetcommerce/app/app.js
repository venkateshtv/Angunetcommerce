var app = angular.module('angnetcommerceapp', ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
    .state('home', {
        url: '/home',
        templateUrl: 'app/home/view.home.html',
        controller:'HomeCtrl'
    })
    .state('products', {
        url: '/products',
        templateUrl: 'app/products/view/products.html',
        controller:'ProductsCtrl'
    })
    .state('productdetail', {
        url: '/productdetail',
        templateUrl: 'app/productdetail/view.productdetail.html',
        controller:'ProductDetailCtrl'
    });

    $urlRouterProvider.otherwise('/home');
    


});