function CoachUsApi() {
    var self = this;
    var tokenKey = 'accessToken';

    // Routes
    self.baseUrl = "http://localhost:36960/";
    self.loginUrl = "Token";
    self.loginRedirectUrl = "/";

    // Route operations

    // Other private operations
    function post(url, useToken, data, doneCallback, failCallback, applyStringify) {
        var headers = {};
        if (useToken !== undefined) {
            headers = getHeaderWithToken();
        }
        if (applyStringify) {
            data = JSON.stringify(data);
        }
        $.ajax({
            type: 'POST',
            url: self.baseUrl + url,
            headers: headers,
            contentType: 'application/json; charset=utf-8',
            data: data
        })
        .done(doneCallback)
        .fail(failCallback);
    };

    function get(url, useToken, data, doneCallback, failCallback, applyStringify) {
        var headers = {};
        if (useToken !== undefined) {
            headers = getHeaderWithToken();
        }
        if (applyStringify) {
            data = JSON.stringify(data);
        }
        $.ajax({
            type: 'GET',
            url: url,
            headers: headers,
            contentType: 'application/json; charset=utf-8',
            data: data
        })
        .done(doneCallback)
        .fail(failCallback);
    };

    function getHeaderWithToken() {
        var token = self.getAccessToken();
        var headers = {};
        if (token) {
            headers.Authorization = 'Bearer ' + token;
        }
        return headers;
    }

    self.redirect = function (url) {        
        window.location.replace(url);
    }

    // Operations
    self.login = function (data, doneCallback, failCallback) {
        post(self.loginUrl, null, data, doneCallback, failCallback);
    };

    self.getErrors = function (jqXHR) {
        var response = null;
        var errors = [];
        var errorsString = "";
        //WE IGNORE MODEL STATE EXTRACTION IF THERE WAS SOME OTHER UNEXPECTED ERROR (I.E. NOT A VALIDATION ERROR)
        //if (x.status == 400) {//SINCE WE ARE RETURNING BAD REQUEST STATUS FROM OUR WEB API, SO WE CHECK IF STATUS CODE IS 400
        try {
            response = JSON.parse(jqXHR.responseText);
        }
        catch (e) { //this is not sending us a ModelState, else we would get a good responseText JSON to parse)
        }
        //}
        if (response != null) {
            if (response.error_description) {
                errorsString = response.error_description;
            }
            else {
                var modelState = response.ModelState;
                //THE CODE BLOCK below IS IMPORTANT WHEN EXTRACTING MODEL STATE IN JQUERY/JAVASCRIPT
                for (var key in modelState) {
                    if (modelState.hasOwnProperty(key)) {
                        errorsString = (errorsString == "" ? "" : errorsString + "<br/>") + modelState[key];
                        errors.push(modelState[key]);//list of error messages in an array
                    }
                }
            }
        }
        else {
            errorsString = jqXHR.status + ': ' + jqXHR.statusText;
        }
        return errorsString;
    }

    // Data
    self.returnUrl = self.siteUrl;

    // Data access operations
    self.setAccessToken = function (accessToken) {
        sessionStorage.setItem(tokenKey, accessToken);
        $.cookie(tokenKey, accessToken, { expires: 7, path: '/' });
    };

    self.getAccessToken = function () {
        return sessionStorage.getItem(tokenKey);
    };    
}
