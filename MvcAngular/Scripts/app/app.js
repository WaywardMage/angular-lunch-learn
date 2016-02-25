var myApp = angular.module("myApp", [])
.config(["$locationProvider", function ($locationProvider) {
    // In order to get the query string from the
    // $location object, it must be in HTML5 mode.

    $locationProvider.html5Mode(true);
}])

