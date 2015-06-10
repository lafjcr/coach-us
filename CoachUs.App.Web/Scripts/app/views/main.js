function mainView(api) {
    var self = this;
    self.api = api;
    self.result = ko.observable();

    // Other private operations

    // Operations
    self.logout = function () {
        api.logout();
        api.redirect("/Account/Login");
    };
}

var mainApp = new mainView(new CoachUsApi());
ko.applyBindings(mainApp);