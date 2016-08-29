/// <reference path="angular.js" />
/// <reference path="Module.js" />

app.controller("myController", function ($scope, $log, myService) {
   
    loadWinners();

    //funciton to load winners
 
    function loadWinners() {
        var winnerGet = myService.getAllWinners();
        winnerGet.then(function (WN) {
            $scope.search = {}
            $scope.searchBy = '$'
            $scope.Winners = WN.data.data
            $scope.TotalWinners=WN.data.total
        },
            function (errWN) {
                $log.error("No records errors");
            });
    }

    // a sample array use for paging
    $scope.list = [];

    $scope.currentPage = 1; // keeps track of the current page
    $scope.pageSize = 5; // holds the number of items per page

    $scope.init = function () { // initialize the sample list with some values
        for (var i = 0; i < 100; i++) {
            $scope.list.push({ 'name': 'name ' + i });
        }
    };

});

//filter for pagination
app.filter('start', function () {
    return function (input, start) {
        if (!input || !input.length) { return; }
 
        start = +start;
        return input.slice(start);
    };
});

//filter for date
 app.filter("mydate", function () {
        var re = /\/Date\(([0-9]*)\)\//;
        return function (x) {
            var m = x.match(re);
            if (m) return new Date(parseInt(m[1]));
            else return null;
        };
    });
//this controller for login
app.controller("CntrlLogin", function ($scope, myService2) {

    $scope.LoginCheck = function () {
        var User = {
            UserName: $scope.uName,
            Password: $scope.password
        };
        $("#divLoading").show();
        var getData = myService2.UserLogin(User);
        getData.then(function (msg) {
            if (msg.data == "0") {
                $("#divLoading").hide();
                $("#alertModal").modal('show');
                $scope.msg = "Password Incorrect !";
            }
            else if (msg.data == "-1") {
                $("#divLoading").hide();
                $("#alertModal").modal('show');
                $scope.msg = "Username Incorrect !";
            }
            else {
                uID = msg.data;
                $("#divLoading").hide();
                window.location.href = "/Home/Index";
            }
        });
       // debugger;
    }

    function clearFields() {
        $scope.uName = '';
        $scope.uPwd = '';
    }

    $scope.alertmsg = function () {
        $("#alertModal").modal('hide');
    };
});


