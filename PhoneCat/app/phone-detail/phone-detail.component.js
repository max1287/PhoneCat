﻿'use strict';

angular.
    module('phoneDetail').
    component('phoneDetail', {
    	templateUrl: "app/phone-detail/phone-detail.template.html",
    	controller: ['Phone', '$routeParams',
            function PhoneDetailController(Phone, $routeParams) {
                var self = this;

            	self.setImage = function setImage(imageUrl) {
            	    self.mainImageUrl = "/api/image?imageUrl="+imageUrl;
            	}

            	self.onDblclick = function onDblclick(imageUrl) {
            		alert('You double-clicked image: ' + imageUrl);
            	};


            	self.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
            	    self.mainImageUrl = "/api/image?imageUrl=" + (self.phone.images[0]==undefined?'default':self.phone.images[0]);
            	});
            }
    	]
    });