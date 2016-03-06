(function (angular) {
    'use strict';
angular.module('App', ['ngRoute'])
.controller('FaqController', function ($rootScope, $scope, $routeParams, $http) {

    $rootScope.visNav = true;
    $rootScope.heading = "FAQ";
    $scope.laster = true;

    function hentAlleKategorier() {
        $http.get("/api/Kategori")
            .success(function (alleKategorier) {
                $scope.kategorier = alleKategorier;
                hentAlleFaq();
            })
            .error(function (data, status) {
                console.log(status + data);
            });
    };

    function hentAlleFaq() {
        $http.get("/api/Faq")
            .success(function (alleFaq) {
                var kat = $scope.kategorier;
                for (var i = 0; i < kat.length; i++) {
                    kat[i].liste = [];
                }
                for (var j = 0; j < alleFaq.length; j++) {
                    for (var k = 0; k < kat.length; k++) {
                        if (kat[k].navn == alleFaq[j].kategori) {
                            kat[k].liste.push(alleFaq[j]);
                        }
                    }
                }
                for (var i = 0; i < kat.length; i++) {
                    if (kat[i].liste.length == 0) {
                        kat.splice(i, 1);
                        i--;
                    }
                }
                $scope.laster = false;
            })
            .error(function (data, status) {
                console.log(status + data);
            });
    };

    hentAlleKategorier();
})

.controller("KontaktController", function ($rootScope, $scope, $http) {
    $scope.visSkjema = true;
    $rootScope.heading = "Kontakt";

    $scope.sendSporsmal = function () {
        var sporsmal = {
            epost: $scope.epost,
            sporsmal: $scope.sporsmal,
            kategori: $scope.kategori
        };

        $http.post("/api/Question/", sporsmal).
            success(function (data) {
                console.log("Spørsmål ble lagret!");
                $scope.visSkjema = false;
            }).
            error(function (data, status) {
                console.log(status + data);
            });
    };

    function hentAlleKategorier() {
        $http.get("/api/Kategori")
            .success(function (alleKategorier) {
                $scope.kategorier = alleKategorier;
            })
            .error(function (data, status) {
                console.log(status + data);
            });
    };
    hentAlleKategorier();
    kontaktScript();
})

.controller("ListeController", function ($rootScope, $scope, $http) {
    $rootScope.visNav = false;
    $rootScope.heading = "Liste";
    $scope.laster = true;

    function hentAlleSporsmal() {
        $http.get("/api/Question")
            .success(function (alleSporsmal) {
                $scope.sporsmal = alleSporsmal;
                $scope.laster = false;
            })
            .error(function (data, status) {
                console.log(status + data);
            });
    };
    hentAlleSporsmal();
})

.config(['$routeProvider', '$locationProvider',function ($routeProvider, $locationProvider) {
    $routeProvider
    .when('/FAQ', {
        templateUrl: "/Scripts/App/Faq.html",
        controller: "FaqController"
    })
    .when('/Kontakt', {
        templateUrl: "/Scripts/App/Kontakt.html",
        controller: "KontaktController"
    })
    .when('/Ansatte', {
        templateUrl: "/Scripts/App/SporsmalListe.html",
        controller: "ListeController"
    })
    .otherwise({ redirectTo: "/FAQ"});

    $locationProvider.html5Mode(true);
}]);
})(window.angular);

