'use strict';

angular.
    module('phoneEdit').
    component('phoneEdit', {
        templateUrl: "app/phone-edit/phone-edit.template.html",
        controller: ['$location', 'Phone', '$routeParams', 'AndroidOs','Upload',
            function PhoneEditController($location, Phone, $routeParams, AndroidOs, Upload) {
                var self = this;
                self.createOrUpdate = false;
                self.androidOs = AndroidOs.query();
                if ($routeParams.phoneId == null) {//create
                    self.createOrUpdate = true;
                    self.phone = new Phone;
                    self.phone.images = [];
                    self.createChanges = function createChanges() {
                        self.phone.name = self.editName;
                        self.phone.description = self.editDescription;
                        self.phone.snippet = self.editSnippet;
                        self.phone.age = self.editAge;
                        Phone.save(self.phone, function () {
                            $location.path('/phones')
                        });
                    }
                }
                else {//update
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
                        self.editName = self.phone.name;
                        self.editDescription = self.phone.description;
                        self.editSnippet = self.phone.snippet;
                        self.editAge = self.phone.age;
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

                self.cancelChanges = function cancelChanges() {
                    $location.path('/phones/' + (self.createOrUpdate ? "" : self.phone.id))
                }
            }
        ]
    });