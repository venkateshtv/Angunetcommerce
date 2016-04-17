var app = angular.module('angnetcommerceapp', ['ui.router', 'angular-flexslider', 'ngLoadingSpinner']);

app.config(function ($stateProvider, $urlRouterProvider) {
    $stateProvider
    .state('home', {
        url: '/home?page',
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
        //if (toState.name == "home") {
        //    $('#banner').show();
        //}
        //else {
        //    $('#banner').hide();
        //}
    });
});

app.directive('ngFiles', ['$parse', function ($parse) {

    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        });
    };

    return {
        link: fn_link
    }
}]);

app.constant("homePageSize", 10);