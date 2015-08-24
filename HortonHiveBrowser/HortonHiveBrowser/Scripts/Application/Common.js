var Common = (function(a) {

    function pageLoading(status) {
        if (status == 'true') {
            $("#loader").css('display', 'block');
        }
        else {
            $("#loader").css('display', 'none');
        }
    }

    a.pageLoading = pageLoading;
    return a;
})(window.Common || {})