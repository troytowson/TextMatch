(function (){
	'use strict';

textMatchService.$inject = ['$http']

	function textMatchService($http){

		function match(text, subtext) {
			return $http.get('/api/v1/textmatching?text=' + text + '&subtext=' + subtext).success(function(result){
				return result;
			});
		};

		var service = {};
		service.match = match;
		return service;
	}

	angular.module('textmatch').factory('textMatchService', textMatchService);
})();