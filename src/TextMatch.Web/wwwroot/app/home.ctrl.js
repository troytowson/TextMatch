(function (){
	'use strict';

	homeController.$inject = ['textMatchService'];

	function homeController(textMatchService){
		var vm = this;
		vm.text = '';
		vm.subtext = '';
		vm.result = '';
		vm.match = match;

		function match(){
			textMatchService.match(vm.text, vm.subtext).then(function (result){
				vm.result = result.data;
			});
		};
	}

	angular.module('textmatch')
		   .controller('homeController', homeController);
})();