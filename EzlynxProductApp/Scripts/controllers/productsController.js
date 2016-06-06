(function () {
    'use strict';
    //Controller declarations & Injecttions
    angular.module('EzLynxProductApp').controller('productsController', productsController);
    productsController.$inject = ['$scope', 'Products', '$location', '$routeParams' ];

    
    function productsController($scope, Products, $location, $routeParams) {
        $scope.title = 'Product Inventory Manager';

        //Declarations
        $scope.models = {};
        $scope.function = {};
        
        //Models

        $scope.models.products = Products.query();
        $scope.models.addProduct = new Products();
        $scope.models.product = new Products();

        //Fucntions 

        //Delete Request
        $scope.function.deleteProduct = function ($index, product) {
            product.$remove({id: product.id}, function () {
                $location.path('/');
                $scope.models.products.splice($index, 1);
            }, function(error){
                console.log("Got an error back from server");
                _displayServerSideValidationErrors($scope, error);
            });
        };

        //Post request
        $scope.function.addNewProduct = function () {
            $scope.models.addProduct.$save(function () {
                $location.path('/');
            }, function (error) {
                console.log("Got an error back from server");
                _displayServerSideValidationErrors($scope, error);
            });
        };

        
        $scope.function.updateProduct = function ($index, product) {

            if( $scope.models.products[$index] === product)
            product.$save(function () {
                $location.path('/');
            }, function (error) {
                console.log("Got an error back from server");
                _displayServerSideValidationErrors($scope, error);
            });
        };

        function _displayServerSideValidationErrors($scope, error) {

            $scope.validationErrors = [];
            var errorObject = error.data;

            if (errorObject) {

                for (var key in errorObject) {
                    var errorMessage = errorObject[key][0];
                    $scope.validationErrors.push(errorMessage);
                }
            }
        }

    }
     
})();
