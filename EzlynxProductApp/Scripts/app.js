(function () {

    'use strict';
    var mainModule = angular.module('EzLynxProductApp', [
        // Angular modules 
         'ngRoute',

        // Service modules
        "productService"

        // 3rd Party Modules
        
    ]);


    mainModule.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        $routeProvider.when('/', {

            templateUrl: 'templates/products.html',
            controller: 'productsController'
        }).when('/product/add', {

            templateUrl: 'templates/addProduct.html',
            controller: 'productsController'
        });

        $locationProvider.html5Mode(true);
    }]);

})();