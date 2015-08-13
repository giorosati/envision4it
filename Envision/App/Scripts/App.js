var app = app || angular.module("EnvisionApp", ['ngRoute']);

app.config(["$routeProvider", '$httpProvider', function ($routeProvider, $httpProvider) {
    $routeProvider.when('/', {
        templateUrl: 'App/Views/Home.html'
    }).when('/login', {
        templateUrl: 'App/Views/Login.html'
    }).when('/AdminHome', {
        templateUrl: 'App/Views/AdminHome.html'
    }).when('/ProjectsAll', {
        templateUrl: 'App/Views/ProjectsAll.html'
    }).when('/ProjectDetails/:id', {
        templateUrl: 'App/Views/ProjectDetails.html'
    }).when('/ProjectEdit/:id', {
        templateUrl: 'App/Views/ProjectEdit.html'
    }).when('/AddProject', {
        templateUrl: 'App/Views/AddProject.html'
    }).when('/SolutionDetails/:id', {
        templateUrl: 'App/Views/SolutionDetails.html'
    }).when('/EditSolutionNotes/:id', {
        templateUrl: 'App/Views/EditSolutionNotes'
        //Hardware management routes
    }).when('/AllHardware', {
        templateUrl: 'App/Views/AdminHardware.html'
    }).when('/EditTickets/:id', {
        templateUrl: 'App/Views/EditTickets'
    }).when('/AddSolutionNotes/:id', {
        templateUrl: 'App/Views/AddSolutionNotes'
    }).when('/AddSolution/:id', {
        templateUrl: 'App/Views/AddSolution.html'
    }).when('/SolutionEdit/:id', {
        templateUrl: 'App/Views/SolutionEdit.html'
        //CustomerContact routes
    }).when('/CustomerContactDetails/:id', {
        templateUrl: 'App/Views/CustomerContactDetails.html'
    }).when('/CustomerContacts/', {
        templateUrl: 'App/Views/CustomerContacts.html'
    }).when('/CustomerContactEdit/:id', {
        templateUrl: 'App/Views/CustomerContactEdit.html'
    }).when('/CustomerContactAdd/', {
        templateUrl: 'App/Views/CustomerContactAdd.html'
        //CustomerNote routes
    }).when('/CustomerNoteDetails/:id', {
        templateUrl: 'App/Views/cnote.html'
    }).when('/CustomerNoteAdd/:id', {
        templateUrl: 'App/Views/CustomerNoteAdd.html'
    }).when('/CustomerNoteEdit/:id', {
        templateUrl: 'App/Views/CustomerNoteEdit.html'
        //contact route
    }).when('/Contact/', {
        templateUrl: 'App/Views/Contact.html'
        //hardware routing
    }).when('/NewHardware/', {
        templateUrl: 'App/Views/AddHardware.html'
    }).when('/AddFAQ/', {
        templateUrl: 'App/Views/AddFAQ.html'
    }).when('/EditFAQ/:id', {
        templateUrl: 'App/Views/EditFAQ.html'
    }).when('/EditHardware/:id', {
        templateUrl: 'App/Views/AddHardware.html'
        // ticket routing
    }).when('/TicketEdit/:id', {
        templateUrl: 'App/Views/TicketEdit.html'
    }).when('/AddTicket/:id', {
        templateUrl: 'App/Views/AddTicket.html'
    }).when('/AllTickets', {
        templateUrl: 'App/Views/AdminTicket.html'
        // user routing
    }).when('/UsersList/', {
        templateUrl: 'App/Views/UsersList.html'
    }).when('/Hardware/:id', {
        templateUrl: 'App/Views/Hardware.html'
    }).when('/Customer', {
        tempateUrl: 'App/Views/Customer.html'
    }).when('/EditHardware/:id', {
        templateUrl: 'App/Views/HardwareEdit.html'
    }).when('/Registration/', {
        templateUrl: 'App/Views/Registration.html'
        //tech login route
    }).when('/t', {
        templateUrl: '/'
        //customer login route
    }).when('/c', {
        templateUrl: 'App/Views/C.html'
        // catch-all route
    }).otherwise({ redirectTo: '/' });

    $httpProvider.interceptors.push('AuthFactory');
}]);