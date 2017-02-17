'use strict';

angular.
    module('core.availability').
    factory('Availability', ['$resource',
        function ($resource) {
            return $resource('api/availability/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
