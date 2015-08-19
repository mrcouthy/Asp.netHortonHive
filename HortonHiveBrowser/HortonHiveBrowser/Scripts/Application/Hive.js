var A = (function (a) {
    function getJson(url) {
        $.getJSON(url, function (json) { $('#jsonOut').text(json['prprty']); });
    }
    a.getJson = getJson;
    return a;
})(window.A || {})

