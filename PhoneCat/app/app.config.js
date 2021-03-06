﻿'use strict';

angular
    .module('phonecatApp')
    .config(['$locationProvider', '$routeProvider',
        function config($locationProvider, $routeProvider) {
            $locationProvider.hashPrefix('!');
            $routeProvider.
                when('/phones', {
                    template: '<phone-list></phone-list>'
                }).
                when('/phones/:phoneId', {
                    template: '<phone-detail></phone-detail>'
                }).
                when('/edit/:phoneId', {
                    template: '<phone-edit></phone-edit>'
                }).
                when('/create/', {
                    template: '<phone-edit></phone-edit>'
                }).
                otherwise('/phones');
        }]);
