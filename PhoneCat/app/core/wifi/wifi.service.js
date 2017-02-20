'use strict';

angular.
    module('core.wifi').
    factory('Wifi', ['$resource',
        function ($resource) {
            return $resource('api/wifi/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
