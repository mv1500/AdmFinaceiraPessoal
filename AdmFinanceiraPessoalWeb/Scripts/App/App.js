(function () {
    "use strict";

    /**
     * Obs.: A ordem dos módulos e plugins/dependências importa para correta injeção de dependência no angularjs
     */
    angular.module("IAdmFin",
        [
            "angucomplete-alt",
            "angular-ladda",
            "datatables",
            "datatables.bootstrap",
            "datatables.buttons",
            "datatables.light-columnfilter",
            "datetime",
            "checklist-model",
            "frapontillo.bootstrap-switch",
            "lr.upload",
            "multiStepForm",
            "ngAnimate",
            "ngResource",
            "ngSanitize",
            "ngValidate",
            "toastr"
        ]);

})();