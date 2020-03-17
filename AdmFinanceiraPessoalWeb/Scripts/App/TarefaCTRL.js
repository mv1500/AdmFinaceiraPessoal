(function () {


    TarefaController.$inject = ["$scope", "$http", "$filter", "datetime", "toastr", "$window"];

    function TarefaController($scope, $http, $filter, datetime, toastr, $window) {

        $scope.viewdata = {};
        
        $scope.viewdata.filtro = {

        };             

        $scope.getViewData = function () {
            $http({
                method: "POST",
                url: "/Tarefa/GetViewData"
            }).then(function success(response) {
                $scope.viewdata.tarefas = response.data;
                $scope.setData();
            });
        }

        $scope.getViewData();

        $scope.setData = function () {

            var data = new Date();

            data.setDate(data.getDate() + 1);

            //data.setDate(1);

            $scope.viewdata.tarefa = {
                DtFim: data
            };                    
        }              

        $scope.validaForm = function (form) {
            if (form.validate()) {
                return true;
            }

            return false;
        }

        $scope.salvarTarefa = function () {

            $http({
                method: "POST",
                url: "/Tarefa/SalvarTarefa",
                data: $scope.viewdata.tarefa
            }).then(function successCallback(response) {
                $("#formCadTarefa").modal("hide");
                $scope.viewdata.tarefa = {};
                $scope.getViewData();
                toastr.success("Tarefa cadastrada.", "Sucesso!");
            }, function errorCallback(response) {
                toastr.error("Serviço indisponível no momento.", "Atenção");
            });
        }

        $scope.concluirTarefa = function (item) {
            
            dateTar = $filter("dateFilter")(item.DtFim, "dd/MM/yyyy");
            timeDur = $filter("dateFilter")(item.DuracaoEstimada, "HH:mm");

            $scope.viewdata.tarefa = angular.copy(item);
            $scope.viewdata.tarefa.DtFim = dateTar;
            $scope.viewdata.tarefa.DuracaoEstimada = timeDur;

            $http({
                method: "POST",
                url: "/Tarefa/ConcluirTarefa",
                data: $scope.viewdata.tarefa
            }).then(function successCallback(response) {
                $scope.viewdata.tarefa = {};
                $scope.getViewData();
                toastr.success("Tarefa Concluida!", "Sucesso!");
            }, function errorCallback(reponse) {
                toastr.error("Serviço indisponível no momento.", "Atenção");                
            });

        }
       

        $scope.excluirTarefa = function (item) {

            bootbox.confirm({
                size: "small",
                title: "Atenção",
                message: "Confirmar exclusão?",
                callback: function (result) {
                    if (!result) return;
                    $http({
                        method: "POST",
                        url: "/Tarefa/ExcluirTarefa",
                        data: item
                    }).then(function successCallback(response) {                       
                        $scope.viewdata.tarefa = {};                     
                        $scope.getViewData();
                        toastr.success("Tarefa excluida.", "Sucesso!");

                    }, function errorCallback(response) {
                        toastr.error("Serviço indisponível no momento.", "Atenção");
                    });
                }
            });

        }

        $scope.modalCadastrarTarefa = function () {

            $("#formCadTarefa").modal("show");

        }       

        $scope.editarTarefa = function (item) {

            $("#formCadTarefa").modal("show");
                        
            dateTar = $filter("dateFilter")(item.DtFim, "dd/MM/yyyy");
            timeDur = $filter("dateFilter")(item.DuracaoEstimada, "HH:mm:ss");

            $scope.viewdata.tarefa = angular.copy(item);
            $scope.viewdata.tarefa.DtFim = dateTar;
            $scope.viewdata.tarefa.DuracaoEstimada = timeDur;
        }
    }

    angular
        .module("IAdmFin")
        .controller("TarefaController", TarefaController)
        .filter("dateFilter", function () {
            return function (item) {
                if (item != null) {
                    return new Date(parseInt(item.substr(6)));
                }
                return "";
            };
        });
})();
