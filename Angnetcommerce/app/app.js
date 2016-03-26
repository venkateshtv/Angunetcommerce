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
        url: '/productdetail/:Stock_No',
        templateUrl: 'app/productdetail/view.productdetail.html',
        controller: 'ProductDetailCtrl',
        cache:false
    });

    $urlRouterProvider.otherwise('/home');
   


});


app.run(function ($rootScope) {
    // you can inject any instance here
    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {
        // do something
        if (toState.name == "home") {
            $('#banner').show();
        }
        else {
            $('#banner').hide();
        }
    });
});
