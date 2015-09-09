(function () {
	'use strict';

	configure.$inject = ['$stateProvider', '$urlRouterProvider'];

	function configure(
		$stateProvider,
        $urlRouterProvider
    ) {
        $urlRouterProvider.otherwise('home');

        $stateProvider
            .state('home', {
                url: '/home',
                templateUrl: '/app/home.html'
            });
    };

	angular.module('textmatch', ['ui.router'])
		   .config(configure);
})();