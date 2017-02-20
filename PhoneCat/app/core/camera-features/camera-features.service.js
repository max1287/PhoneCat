'use strict';

angular.
    module('core.cameraFeatures').
    factory('CameraFeatures', ['$resource',
        function ($resource) {
            return $resource('api/cameraFeatures/', {}, {
                'query': {
                    method: 'GET',
                    isArray: true
                }
            });
        }
    ]);
