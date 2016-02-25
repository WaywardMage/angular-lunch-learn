myApp
//Dirt-simple controller, just picks up the JSON that was output by the server
.controller("personJsonListController", function ($scope, personService) {
    $scope.persons = window.persons;
})

//A little more angular-esque -- fetches the list on demand
.controller("personListController", function ($scope, personService) {
    personService.getPersons().then(function (persons) {
        $scope.persons;
    });
})

//Dirt-simple controller, just picks up the JSON that was output by the server
.controller("personJsonController", function ($scope, $location, personService) {
    $scope.person = window.person;
    $scope.savePerson = function () {
        var loc = $location;
        var useAngular = false;
        if (loc.search().useAngular) {
            useAngular = true;
        }
        personService.savePerson(person).then(function (response) {
            if (response.success) {
                alert("Saved!");
                window.location.href = "/Person" + (useAngular ? "?useAngular=true" : "");
            } else {
                alert("Failed: " + response.errorMessage);
            }
        });
    }
})

//A little more angular-esque -- fetches the person on demand
.controller("personController", function ($scope, $location, personService) {
    var loc = $location.path();
    var id = loc.substr(loc.lastIndexOf('/') + 1);

    personService.getPerson(id).then(function (person) {
        $scope.person = person;
    });

    $scope.savePerson = function () {
        personService.savePerson(person).then(function (response) {
            if (response.success) {
                alert("Saved!");
                window.location.href = "/Person";
            } else {
                alert("Failed: " + response.errorMessage);
            }
        });
    }
})

