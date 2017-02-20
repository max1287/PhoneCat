﻿'use strict';

angular.
    module('phoneEdit').
    component('phoneEdit', {
        templateUrl: "app/phone-edit/phone-edit.template.html",
        controller: ['$location', 'Phone', '$routeParams', 'AndroidOs', 'AndroidUi', 'BatteryType', 'Upload',
            'Availability', 'DisplayResolution', 'CameraFeatures', 'Bluetooth', 'Wifi', 'Processor','Usb',
            function PhoneEditController($location, Phone, $routeParams, AndroidOs, AndroidUi, BatteryType, Upload,
                Availability, DisplayResolution, CameraFeatures, Bluetooth, Wifi, Processor, Usb) {
                var self = this;
                self.createOrUpdate = false;
                self.androidOs = AndroidOs.query();
                self.androidUi = AndroidUi.query();
                self.availability = Availability.query();
                self.batteryTypes = BatteryType.query();
                self.displayResolutions = DisplayResolution.query();
                self.cameraFeatures = CameraFeatures.query();
                self.bluetooth = Bluetooth.query();
                self.wifi = Wifi.query();
                self.processors = Processor.query();
                self.usbs = Usb.query();
                self.selectedResolution = "";
                self.availabilityItem = "";
                self.cameraFeatureItem = "";
                self.wifiItem = "";

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
                    self.phone.camera = new Object();
                    self.phone.cameraFeatures = [];
                    self.phone.connectivity = new Object();
                    self.phone.connectivity.wifi = [];
                    self.phone.hardware = new Object();
                }
                else {//update
                    self.phone = Phone.get({ phoneId: $routeParams.phoneId }, function (phone) {
                        self.selectedResolution = self.phone.display.height + 'x' + self.phone.display.width;
                    });
                }

                self.createChanges = function createChanges() {
                    var resolutions = self.selectedResolution.split('x');
                    if (resolutions.length == 2) {
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
                    if (self.availabilityItem != "") {
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

                self.addFeatureItem = function addFeatureItem() {
                    if (self.cameraFeatureItem != "") {
                        if (self.phone.cameraFeatures.indexOf(self.cameraFeatureItem) < 0)
                            self.phone.cameraFeatures.push(self.cameraFeatureItem);
                        self.cameraFeatureItem = "";
                    }
                }

                self.deleteFeatureItem = function deleteFeatureItem(item) {
                    var index = self.phone.cameraFeatures.indexOf(item);
                    if (index >= 0)
                        self.phone.cameraFeatures.splice(index, 1);
                }
                
                self.deleteWifiItem = function deleteWifiItem(item) {
                    var index = self.phone.connectivity.wifi.indexOf(item);
                    if (index >= 0)
                        self.phone.connectivity.wifi.splice(index, 1);
                }

                self.addWifiItem = function addWifiItem() {
                    if (self.wifiItem != "") {
                        if (self.phone.connectivity.wifi.indexOf(self.wifiItem) < 0)
                            self.phone.connectivity.wifi.push(self.wifiItem);
                        self.wifiItem = "";
                    }
                }

                self.deleteImage = function deleteImage(image) {
                    var index = self.phone.images.indexOf(image);
                    if (index >= 0)
                        self.phone.images.splice(index, 1);
                }

                self.cancelChanges = function cancelChanges() {
                    $location.path('/phones/' + (self.createOrUpdate ? "" : self.phone.id))
                }

                self.doSubmit = function doSubmit() {
                    if (self.createOrUpdate)
                        self.createChanges();
                    else self.saveChanges();
                };
            }
        ]
    });