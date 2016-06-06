(function () {
    'use strict';
    //Custom Services & Provider Modules declartions 
    var productService = angular.module('productService', ['ngResource']);

    
    productService.factory('Products', ['$resource', function ($resource) {

        return $resource('/api/Products/', {}, {

            query: { method: 'GET', params: {}, isArray: true }
        });
    }]);

})();