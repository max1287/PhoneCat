'use strict';

angular.
    module('core.image').
    factory('Image', ['$resource',
        function ($resource) {
            return $resource('api/image/:imageUrl', {}, {
                'query': {
                    method: 'GET',
                    params: { imageUrl: '' }
                },
                'save': {
                    method: 'POST'
                }
            });
        }
    ]);