'use strict';

angular.
    module('core.androidUi').
    factory('AndroidUi', ['$resource',
        function ($resource) {
            return $resource('api/androidui/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
