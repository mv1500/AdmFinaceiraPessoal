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

        $scope.setData = function () {

            var data = new Date();

            data.setMonth(data.getMonth() + 1);

            data.setDate(1);

            $scope.viewdata.conta = {
                DataPagamento: data
            };                    
        }              

        $scope.validaForm = function (form) {
            if (form.validate()) {
                return true;
            }

            return false;
        }

        $scope.salvarConta = function () {

            $http({
                method: "POST",
                url: "/ContaMes/SalvarConta",
                data: $scope.viewdata.conta
            }).then(function successCallback(response) {
                $("#formCadConta").modal("hide");
                $scope.viewdata.conta = {};
            }, function errorCallback(response) {

            });
        }



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

