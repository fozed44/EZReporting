/// <reference path="https://code.jquery.com/jquery-1.10.2.js" />

$('#btnEditReport').click(function () {
    var url = $(this).data('target');
    var reportName = $('#slctReports').val();
    if (reportName == '__NONE__') return;
    window.location = url + "?" + $.param({
        reportName: reportName
    });
});