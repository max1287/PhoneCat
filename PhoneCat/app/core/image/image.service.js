'use strict';

angular.
    module('core.image').
    factory('Image', ['$resource',
        function ($resource) {
            return $resource('api/image/', { }, {
                'save': {
                    method: 'POST',
                    headers: { 'Content-Type': undefined},
                    transformRequest: function (data) {
                        var fd = new FormData();
                        angular.forEach(data, function (value, key) {
                            fd.append(key, value);
                        });
                        return fd;
                    },
                    isArray:true
                }
            });
        }
    ]);
