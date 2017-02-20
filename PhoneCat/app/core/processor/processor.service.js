'use strict';

angular.
    module('core.processor').
    factory('Processor', ['$resource',
        function ($resource) {
            return $resource('api/processor/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
