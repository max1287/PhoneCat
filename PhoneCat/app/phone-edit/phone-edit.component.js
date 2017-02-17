'use strict';

angular.
    module('phoneEdit').
    component('phoneEdit', {
        templateUrl: "app/phone-edit/phone-edit.template.html",
        controller: ['$location', 'Phone', '$routeParams', 'AndroidOs', 'AndroidUi', 'BatteryType', 'Upload', 'Availability', 'DisplayResolution',
            function PhoneEditController($location, Phone, $routeParams, AndroidOs, AndroidUi, BatteryType, Upload, Availability, DisplayResolution) {
                var self = this;
                self.createOrUpdate = false;
                self.androidOs = AndroidOs.query();
                self.androidUi = AndroidUi.query();
                self.availability = Availability.query();
                self.batteryTypes = BatteryType.query();
                self.displayResolutions = DisplayResolution.query();
                self.selectedResolution = "";
                self.addAvailabilityItem = "";

                if ($routeParams.phoneId == null) {//create
                    self.createOrUpdate = true;
                    self.phone = new Object();
                    self.phone.images = [];
                    self.phone.availability = [];
                    self.phone.battery = new Object();
                    self.phone.android = new Object();
                    self.phone.display = new Object();
                    self.phone.storage = new Object();
                    self.phone.sizeAndWeight = new Object();
                }
                else {//update
                    self.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
                        self.selectedResolution = self.phone.display.height + 'x' + self.phone.display.width;
                    });
                }

                self.createChanges = function createChanges() {
                    var resolutions = self.selectedResolution.split('x');
                    if (resolutions.count > 0) {
                        self.phone.display.height = resolutions[0];
                        self.phone.display.width = resolutions[1];
                    }
                    Phone.save(self.phone, function () {
                        $location.path('/phones')
                    });
                }

                self.saveChanges = function saveChanges() {
                    var resolutions = self.selectedResolution.split('x');
                    self.phone.display.height = resolutions[0];
                    self.phone.display.width = resolutions[1];
                    Phone.update({ phoneId: self.phone.id }, self.phone, function () {
                        $location.path('/phones/' + self.phone.id)
                    });
                }

                self.uploadPic = function uploadPic(files) {
                    self.Images = files;

                    //Image.save(self.Image);
                    angular.forEach(files, function (file) {
                        file.upload = Upload.upload({
                            url: 'api/image',
                            data: { file: file }
                        });
                        file.upload.then(function (response) {
                            file.result = response.data;
                            for (var i = 0; i < file.result.length; i++) {
                                self.phone.images.push(file.result[i]);
                            }

                        });
                    });
                }

                self.addAvailabilityItem = function addAvailabilityItem() {
                    if (self.addAvailabilityItem != "") {
                        if (self.phone.availability.indexOf(self.availabilityItem) < 0)
                            self.phone.availability.push(self.availabilityItem);
                        self.availabilityItem = "";
                    }
                }

                self.deleteAvailabilityItem = function deleteAvailabilityItem(item) {
                    var index = self.phone.availability.indexOf(item);
                    if (index >= 0)
                        self.phone.availability.splice(index,1);
                }

                self.deleteImage = function deleteImage(image) {
                    var index = self.phone.images.indexOf(image);
                    if (index >= 0)
                        self.phone.images.splice(index, 1);
                }

                self.cancelChanges = function cancelChanges() {
                    $location.path('/phones/' + (self.createOrUpdate ? "" : self.phone.id))
                }
            }
        ]
    });