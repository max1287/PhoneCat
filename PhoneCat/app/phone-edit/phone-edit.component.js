'use strict';

angular.
    module('phoneEdit').
    component('phoneEdit', {
    	templateUrl: "app/phone-edit/phone-edit.template.html",
    	controller: ['$location', 'Phone', '$routeParams',
            function PhoneEditController($location, Phone, $routeParams) {
            	var self = this;
            	
            	self.setImage = function setImage(imageUrl) {
            		self.mainImageUrl = imageUrl;
            	}

            	self.saveChanges = function saveChanges() {
            	    self.phone.name = self.editName;
            	    self.phone.description = self.editDescription;
            	    self.phone.snippet = self.editSnippet;
            	    self.phone.age = self.editAge;
            	    Phone.update({ phoneId: self.phone.id }, self.phone, function () {
            	        $location.path('/phones/' + self.phone.id)
            	    });
            	}

                self.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
                    //self.setImage(self.phone.images[0]);
                    self.editName = self.phone.name;
                    self.editDescription = self.phone.description;
                    self.editSnippet = self.phone.snippet;
                    self.editAge = self.phone.age;
                });
            }
    	]
    });