(function() {
    'use strict';

    angular
        .module('app')
        .controller('Customer', Customer);

    Customer.$inject = ['$location'];

    function Customer($location)
    {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'Customer';

        activate();

        function activate() { }
    }
})();
