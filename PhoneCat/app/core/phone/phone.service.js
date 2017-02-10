'use strict';

angular.
    module('core.phone').
    factory('Phone', ['$resource',
        function ($resource) {
            return $resource('api/phones', {}, {
                query: {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);