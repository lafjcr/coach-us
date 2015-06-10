function loginView(api) {
    var self = this;
    self.api = api;
    self.result = ko.observable();

    //self.viewModel = ko.validatedObservable({
    //    username: ko.observable().extend({ required: true }),
    //    password: ko.observable().extend({ required: true }),
    //    rememberMe: ko.observable()
    //});

    self.viewModel = {
        username: ko.observable().extend({
            required: {
                params: true,
                message: "Username is required"
            }
        }),
        password: ko.observable().extend({
            required: {
                params: true,
                message: "Password is required"
            }
        }),
        rememberMe: ko.observable()
    };

    // Other private operations
    function loginDoneCallback(data) {
        var redirectUrl = "/Home/Index";

        api.setAccessToken(data.access_token);
        api.redirect(redirectUrl);
    }

    function loginFailCallback(data) {
        self.result(api.getErrors(data));
    }

    // Operations
    self.login = function () {
        //if (self.viewModel.isValid()) {
            var data = {
                grant_type: 'password',
                username: self.viewModel.username(),
                password: self.viewModel.password()
            };            

            api.login(data, loginDoneCallback, loginFailCallback);
        //}
    };

    // Data
    self.returnUrl = self.siteUrl;
}

var app = new loginView(new CoachUsApi());
ko.applyBindings(app);