'use strict';

angular.
    module('core.batteryType').
    factory('BatteryType', ['$resource',
        function ($resource) {
            return $resource('api/batterytype/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
