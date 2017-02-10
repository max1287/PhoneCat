'use strict';

angular.
    module('phoneEdit').
    component('phoneEdit', {
    	templateUrl: "app/phone-edit/phone-edit.template.html",
    	controller: ['Phone', '$routeParams',
            function PhoneEditController(Phone, $routeParams) {
            	var self = this;
            	
            	self.setImage = function setImage(imageUrl) {
            		self.mainImageUrl = imageUrl;
            	}
                self.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
                    //self.setImage(self.phone.images[0]);
                    self.editName = self.phone.name;
                    self.editDescription = self.phone.description;
                });
            }
    	]
    });