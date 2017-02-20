'use strict';

angular.
    module('core.usb').
    factory('Usb', ['$resource',
        function ($resource) {
            return $resource('api/usb/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
