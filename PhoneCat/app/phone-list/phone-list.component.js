'use strict';

angular.
    module('phoneList').
    component('phoneList', {
        templateUrl: "app/phone-list/phone-list.template.html",
        controller: ['Phone',
            function PhoneListController(Phone){
                this.phones = Phone.query();
            }
        ]
    });