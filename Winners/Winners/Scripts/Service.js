/// <reference path="angular.js" />
/// <reference path="Module.js" />

//this service for displying data
app.service("myService", function ($http) {
    //Get All Winners
    this.getAllWinners = function () {
        return $http.get("/Winners/getWinners");
    }


});


//this service for login
app.service("myService2", function ($http) {

    this.UserLogin = function (User) {
        var response = $http({
            method: "post",
            url: "/Login/Login",
            data: JSON.stringify(User),
            dataType: "json"
        });
        return response;
    }

});

