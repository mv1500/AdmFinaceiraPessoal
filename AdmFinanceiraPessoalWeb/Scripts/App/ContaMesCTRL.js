(function () {


    ContaController.$inject = ["$scope", "$http", "$filter", "datetime", "toastr", "$window"];

    function ContaController($scope, $http, $filter, datetime, toastr, $window) {

        $scope.viewdata = {};

        $scope.viewdata.filtro = {

        };

             

        $scope.getViewData = function () {
            $http({
                method: "POST",
                url: "/ContasMes/GetViewData"
            }).then(function success(response) {

                alert(response.data);
                $scope.viewdata.contas = response.data;                
            });
        }

        $scope.getViewData();


    }

    angular
        .module("IAdmFin")
        .controller("ContaController", ContaController)
        .filter("dateFilter", function () {
            return function (item) {
                if (item != null) {
                    return new Date(parseInt(item.substr(6)));
                }
                return "";
            };
        });
})();

