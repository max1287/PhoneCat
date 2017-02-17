'use strict';

angular.
    module('core.displayResolution').
    factory('DisplayResolution', ['$resource',
        function ($resource) {
            return $resource('api/display/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
