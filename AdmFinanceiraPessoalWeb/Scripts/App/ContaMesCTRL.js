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
                $scope.viewdata.contas = response.data;
                $scope.setData();
                            });
        }

        $scope.getViewData();

        $scope.setData = function () {

            var data = new Date();

            data.setMonth(data.getMonth() + 1);

            //data.setDate(1);

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
                url: "/ContasMes/SalvarContaMes",
                data: $scope.viewdata.conta
            }).then(function successCallback(response) {
                $("#formCadConta").modal("hide");
                $scope.viewdata.conta = {};
                $scope.getViewData();
                toastr.success("Conta cadastrada.", "Sucesso!");
            }, function errorCallback(response) {
                toastr.error("Serviço indisponível no momento.", "Atenção");
            });
        }

        $scope.salvarPagamento = function () {

            $scope.viewdata.pagamento.IdContaMes = $scope.viewdata.conta;

            $http({
                method: "POST",
                url: "/ContasMes/Pagar",
                data: $scope.viewdata.pagamento
            }).then(function successCallback(response) {               
                $("#formCadPagamento").modal("hide");
                $scope.viewdata.pagamento = {};
                $scope.viewdata.conta = {};
                $scope.getViewData();
                toastr.success("Pagamento cadastrado.", "Sucesso!");  
            }, function errorCallback(response) {

            });
        }         

        $scope.excluirConta = function (item) {

            bootbox.confirm({
                size: "small",
                title: "Atenção",
                message: "Confirmar exclusão?",
                callback: function (result) {
                    if (!result) return;
                    $http({
                        method: "POST",
                        url: "/Conta/ExcluirConta",
                        data: item
                    }).then(function successCallback(response) {                       
                        $scope.viewdata.conta = {};                     
                        $scope.getViewData();
                        toastr.success("Conta excluida.", "Sucesso!");

                    }, function errorCallback(response) {
                        toastr.error("Serviço indisponível no momento.", "Atenção");
                    });
                }
            });

        }

        $scope.modalCadastrarConta = function () {

            $("#formCadConta").modal("show");

        }

        $scope.modalCadastrarPagamento = function (item) {

            $("#formCadPagamento").modal("show");

            dateCon = $filter("dateFilter")(item.DataPagamento, "dd/MM/yyyy");

            $scope.viewdata.conta = angular.copy(item);
            $scope.viewdata.conta.DataPagamento = dateCon;
          
        }

        $scope.editarCon = function (item) {

            $("#formCadConta").modal("show");
                        
            dateCon = $filter("dateFilter")(item.DataPagamento, "dd/MM/yyyy");

            $scope.viewdata.conta = angular.copy(item);
            $scope.viewdata.conta.DataPagamento = dateCon;
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

