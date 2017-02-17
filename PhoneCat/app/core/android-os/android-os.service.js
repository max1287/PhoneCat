'use strict';

angular.
    module('core.androidOs').
    factory('AndroidOs', ['$resource',
        function ($resource) {
            return $resource('api/androidos/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
