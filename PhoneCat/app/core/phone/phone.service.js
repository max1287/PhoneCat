'use strict';

angular.
    module('core.phone').
    factory('Phone', ['$resource',
        function ($resource) {
            return $resource('api/phones/:phoneId', {}, {
                'query': {
                    method: 'GET',
                    params: { phoneId: '' },
                    isArray: true
                },
                'update': {
                    method: 'PUT'
                }
            });
        }
    ]);