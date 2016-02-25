myApp.factory("personService", function ($http) {
    var options = {
        baseUrl: "/Person",
        getPersonUrl: "/GetPerson",
        getPersonsUrl: "/GetPersons",
        savePersonUrl: "/SavePerson",
    }
    return {
        getPerson: function (id) {
            //fetch some fake users from JSONPlaceHolder and return the promise
            return $http.post(options.baseUrl + options.getPersonUrl, { id: id }).then(function (response) {
                return response.data;
            });
        },
        getPersons: function () {
            //fetch some fake users from JSONPlaceHolder and return the promise
            return $http.post(options.baseUrl + options.getPersonsUrl).then(function (response) {
                return response.data;
            });
        },
        savePerson: function (person) {
            //fetch some fake users from JSONPlaceHolder and return the promise
            return $http.post(options.baseUrl + options.savePersonUrl, { person: person }).then(function (response) {
                return response.data;
            });
        }
    }
});