/// <reference path="https://code.jquery.com/jquery-1.10.2.js" />
/// <reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.5.8/angular.min.js" />

var CreateApp = angular.module("CreateApp", []);

CreateApp.controller('CreateController', ['$scope', '$http', function ($scope,$http) {

    $scope.procedures = [];
    $scope.schemas = [];
    $scope.procName = '';
    $scope.database = '';
    $scope.schema = '';

    $('#slctDatabase').change(function () {
        $scope.database = $(this).val();
        var schema = $("#slctSchema").val();
        $scope.procName = "";
        requestSchemas($scope.database);
    });

    $('#slctSchema').change(function () {
        $scope.schema = $(this).val();
        $scope.procName = "";
        requestProcs($scope.database, $scope.schema);
    });

    $('#slctProc').change(function () {
        $scope.procName = $(this).val();
        $('#lblEnterReportName').text('Enter Report Name For ' + $scope.database + '.' +
                                      $scope.schema + '.' + $scope.procName);
        $scope.$apply();
    });

    $('#btnCreate').click(function () {
        var reportName = $('#txtReportName').val();
        createReport(
            reportName,
            $scope.database,
            $scope.schema,
            $scope.procName
        );
    });

    function requestProcs(database, schema){
        $http({
            url: "/CreateReport/GetProcedures",
            method: 'GET',
            params: {
                database: database,
                schema: schema
            }
        }).then(function (response) {
            $scope.procedures = [];
            response.data.procs.forEach(function (item) {
                $scope.procedures.push(item);
            });
        }, function (response) {
            alert("Server-side Error: " + response);
        });
    }

    function requestSchemas(database) {
        $http({
            url: '/CreateReport/GetSchemas',
            method: 'GET',
            params: {
                database: database
            }
        }).then(function (response) {
            $scope.procedures = [];
            $scope.schemas = [];
            response.data.schemas.forEach(function (item) {
                $scope.schemas.push(item);
            })
        }, function (response) {
            alert("Server-side Error: " + response);
        });
    }

    function createReport(reportName, database, schema, proc) {
        $http({
            url: '/CreateReport/CreateReport',
            method: 'POST',
            data: {
                reportName: reportName,
                database:   database,
                schema:     schema,
                procedure:  proc
            }
        }).then(function (response) {
            if (response.data && response.data.success) {
                alert('Report Created.');
                return;
            }
            if (!response.data || !response.data.errorMessage) {
                alert('Unknown Server-side error.');
                return;
            }
            alert(response.data.errorMessage);
        }, function () {
            alert('Unknown Server-side error.');
        });
    }

}]);