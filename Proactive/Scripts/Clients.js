/**
 *
 *  Defino este unico modulo acá por una cuestion de que me pareció suficiente
 *  sin necesidad de separar mucho la lógica entre modulos, controllers, services, etc
 *  ya que es una app con pocas funcionalidad y con propositos de mostrar conceptos basicos de programacion
 *  
 **/
var app = angular.module('proactiveDemo', []);
 app.controller('clientsCtrl', function ($rootScope, $scope, $http) {

    // Config base endpoint
    $rootScope.baseapiUrl = 'http://localhost:57359/api';

    $scope.clientes = [];

    $scope.sortType = 'codigo';  // default sort type
    $scope.sortReverse = false;  // default sort order (ASC)
    $scope.searchTerm = '';      // default search/filter name term
    $scope.searchCountry = '';   // default filter country code

    // Single ViewModel
    $scope.Cliente = {
        Codigo: '',
        Cuenta: '',
        Nombre: '',
        State: { Codigo: '' },
        Country: { Codigo: '' }
    };

    // Setup initial data
    var init = function () {
        $scope.cancel();

        $http.get($rootScope.baseapiUrl + '/clients').then(function (res) {
            $scope.clientes = res.data;           
        });

        $http.get($rootScope.baseapiUrl + '/countries').then(function (res) {
            $scope.paises = res.data;         
        });
    }

    // Reset Client VM details
    $scope.clear = function () {
        $scope.Cliente.Codigo = '';
        $scope.Cliente.Cuenta = '';
        $scope.Cliente.Nombre = '';
        $scope.Cliente.State.Codigo = '';
        $scope.Cliente.Country.Codigo = '';
    }

    // Show New Client form
    $scope.add = function () {
        $scope.isNew = true;
    }

    // Toggle Client VM details
    $scope.edit = function (data) {
        $scope.isNew = false;
        $scope.Cliente = {
            Codigo: data.Codigo,
            Cuenta: data.Cuenta,
            Nombre: data.Nombre,
            State: { Codigo: data.State.Codigo },
            Country: { Codigo: data.Country.Codigo }
        };
        $scope.getEstados(data.Country.Codigo);
    }

    // Reset forms
    $scope.cancel = function () {
        $scope.clear();
        $scope.isNew = false;
    }

    // Create Client
    $scope.save = function () {
        if ($scope.Cliente.Cuenta > 0 && $scope.Cliente.Nombre != "" && $scope.Cliente.State.Codigo != "" && $scope.Cliente.Country.Codigo != "") {
            $http({
                method: 'POST',
                url: $rootScope.baseapiUrl + '/clients',
                data: $scope.Cliente
            }).then(
               function successCallback(response) {
                   init();
                   alert("Cliente guardado exitosamente!");
               }, function errorCallback(response) {
                   alert('Oops! Ha ocurrido un problema...');
               });
        }
        else {
            alert('Por favor ingrese todos los campos requeridos!');
        }
    };

    // Update Client
    $scope.update = function () {
        if ($scope.Cliente.Cuenta > 0 && $scope.Cliente.Nombre != "" && $scope.Cliente.State.Codigo != "" && $scope.Cliente.Country.Codigo != "") {
            $http({
                method: 'PUT',
                url: $rootScope.baseapiUrl + '/clients/' + $scope.Cliente.Codigo,
                data: $scope.Cliente
            }).then(
              function successCallback(response) {
                  init();
                  alert("Cliente guardado exitosamente!");
              }, function errorCallback(response) {
                  alert('Oops! Ha ocurrido un problema...');
              });
        }
        else {
            alert('Por favor ingrese todos los campos requeridos!');
        }
    };

    // Delete Client
    $scope.delete = function (id) {
        $http({
            method: 'DELETE',
            url: $rootScope.baseapiUrl + '/clients/' + id,
        }).then(
           function successCallback(response) {
               alert("Cliente eliminado correctamente!");
               init();
           }, function errorCallback(response) {
               alert('Oops! Ha ocurrido un problema...');
           });
    };

    // Get States by Country code
    $scope.getEstados = function (codigo_pais) {
        if (codigo_pais > 0) {
            $http({
                method: 'GET',
                url: $rootScope.baseapiUrl + '/states/' + codigo_pais
            }).then(function (response) {
                $scope.estados = response.data;
            });
        }
        else {
            $scope.estados = null;
        }
    }

    $scope.countryFilter = function(data) {
        if ($scope.searchCountry != null && $scope.searchCountry != "") {        
            return (data.Country.Codigo == $scope.searchCountry);
        }
        else {
            return true;
        }
    }


    // Start...
    init();

});