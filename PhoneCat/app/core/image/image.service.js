'use strict';

angular.
    module('core.image').
    factory('Image', ['$resource',
        function ($resource) {
            return $resource('api/image?imageUrl=:imageUrl', {}, {
                'get': {
                    method: 'GET',
                    params: {imageUrl: ''}
                },
                'delete': {
                    method: 'DELETE',
                    params: {imageUrl: ''}
                }

            });
        }
    ]);
