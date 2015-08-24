﻿var A = (function(a) {

    function buildHtmlTable(myList) {
        var columns = addAllColumnHeaders(myList);

        for (var i = 0; i < myList.length; i++) {
            var row$ = $('<tr/>');
            for (var colIndex = 0; colIndex < columns.length; colIndex++) {
                var cellValue = myList[i][columns[colIndex]];

                if (cellValue == null) {
                    cellValue = "";
                }

                row$.append($('<td/>').html(cellValue));
            }
            $("#jsonOut").append(row$);
        }
    }

    // Adds a header row to the table and returns the set of columns.
    // Need to do union of keys from all records as some records may not contain
    // all records
    function addAllColumnHeaders(myList) {
        var columnSet = [];
        var headerTr$ = $('<tr/>');

        for (var i = 0; i < myList.length; i++) {
            var rowHash = myList[i];
            for (var key in rowHash) {
                if ($.inArray(key, columnSet) == -1) {
                    columnSet.push(key);
                    headerTr$.append($('<th/>').html(key));
                }
            }
        }
        $("#jsonOut").html(headerTr$);

        return columnSet;
    }

    function getHiveData(url) {
        Common.pageLoading('true');
        var text = $('#HiveQL').val();
        $.getJSON(url, { hiveQL: text, time: "2pm" }, function(json) {
            buildHtmlTable(json.dt);
            Common.pageLoading('false');
            //  $('#jsonOut').text(JSON.stringify(json));
        });
    }

    a.getHiveData = getHiveData;
    return a;
})(window.A || {})