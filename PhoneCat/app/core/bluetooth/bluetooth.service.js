'use strict';

angular.
    module('core.bluetooth').
    factory('Bluetooth', ['$resource',
        function ($resource) {
            return $resource('api/bluetooth/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
