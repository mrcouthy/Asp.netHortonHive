var A = (function (a) {
    function getJson(url) {
        $.getJSON(url, { parameter: "John", time: "2pm" }, function (json) { $('#jsonOut').text(json['prprty']); });
    }
    a.getJson = getJson;
    return a;
})(window.A || {})

