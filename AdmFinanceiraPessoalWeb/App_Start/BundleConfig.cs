using System.Web;
using System.Web.Optimization;

namespace AdmFinanceiraPessoalWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-plugins").Include(
                "~/Scripts/jquery/plugins/spin/spin.js",
                "~/Scripts/jquery/plugins/ladda/ladda.js",
                "~/Scripts/jquery/plugins/typeahead/typeahead.bundle.js",
                "~/Scripts/jquery/plugins/typeahead/typeahead.jquery.js",
                "~/Scripts/jquery/plugins/handlebars/handlebars.js",
                "~/Scripts/jquery/plugins/bloodhound/bloodhound.js",
                "~/Scripts/jquery/plugins/bootbox/bootbox.min.js",
                "~/Scripts/jquery/plugins/bootstrap-tour/bootstrap-tour.min.js",
                "~/Scripts/jquery/plugins/bootstrap-tour/bootstrap-tour-standalone.min.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery/jquery.validate*",
                "~/Scripts/jquery/additional-methods.min.js",
                "~/Scripts/jquery/messages_pt_BR.js",
                "~/Scripts/jquery/jquery.mask.min.js",
                "~/Scripts/app/jquery.config.js"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
               "~/Scripts/bootstrap/bootstrap.js",
               "~/Scripts/bootstrap/bootstrap-datepicker.js",
               "~/Scripts/bootstrap/locales/bootstrap-datepicker.pt-BR.min.js",
               "~/Scripts/bootstrap/bootstrap-switch.js",
               "~/Scripts/bootstrap/bootstrap-select.js",
               "~/Scripts/bootstrap/respond.js"
               ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Scripts/jquery/plugins/bootstrap-tour/bootstrap-tour.min.css",
                "~/Scripts/jquery/plugins/bootstrap-tour/bootstrap-tour-standalone.min.css",

                "~/Content/pretty-checkbox.css",

                "~/Content/bootstrap.css",
                "~/Content/bootstrap-theme.min.css",
                "~/Content/bootstrap-checkbox.css",
                "~/Content/bootstrap-datepicker3.css",
                "~/Content/bootstrap-switch.css",
                "~/Content/bootstrap-select.css",

                "~/Content/ladda-themeless.min.css",
                "~/Content/Table.css",

                "~/Scripts/angular/plugins/angular-toastr/angular-toastr.min.css",
                "~/Scripts/angular/plugins/dataTables/datatables.min.css",
                "~/Scripts/angular/plugins/dataTables/angular-datatables.min.css",
                "~/Scripts/angular/plugins/dataTables/datatables.bootstrap.min.css",

                "~/Scripts/angular/plugins/angucomplete-alt.css",

                "~/Content/site.css",
                "~/Content/menuLateral.css"));
            CustomBundles(bundles);

            RegisterApp(bundles);


            BundleTable.EnableOptimizations = true;

        }

        private static void CustomBundles(BundleCollection bundles)
        {
            #region AngularJS

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                 "~/Scripts/angular/angular.min.js",
                 "~/Scripts/angular/angular-resource.min.js",
                 "~/Scripts/angular/angular-sanitize.min.js",
                 "~/Scripts/angular/angular-locale_pt-br.js",
                 "~/Scripts/angular/angular-upload.min.js",
                 "~/Scripts/angular/angular-animate.min.js",
                 "~/Scripts/angular/plugins/angular-validate.min.js",
                 "~/Scripts/angular/plugins/angular-ladda.min.js",
                 "~/Scripts/angular/plugins/angular-multi-step-form.min.js",
                 "~/Scripts/angular/plugins/checklist-model.js",
                 "~/Scripts/angular/plugins/angular-toastr/angular-toastr.tpls.min.js",
                 "~/Scripts/angular/plugins/datetime.js",
                 "~/Scripts/angular/plugins/dataTables/datatables.min.js",
                 "~/Scripts/angular/plugins/dataTables/dataTables.lightColumnFilter.js",
                 "~/Scripts/angular/plugins/dataTables/angular-datatables.min.js",
                 "~/Scripts/angular/plugins/dataTables/buttons/angular-datatables.buttons.min.js",
                 "~/Scripts/angular/plugins/dataTables/angular-datatables.bootstrap.min.js",
                 "~/Scripts/angular/plugins/dataTables/angular-datatables.light-columnfilter.js",
                 "~/Scripts/angular/plugins/angular-bootstrap-switch.min.js",
                 "~/Scripts/angular/plugins/angucomplete-alt.min.js",
                 "~/Scripts/app/app.js",
                  "~/Scripts/moment.js",
                 "~/Scripts/app/directives.js",
                 "~/Scripts/app/configSrv.js",
                 "~/Scripts/app/config.js"
                 ));

            #endregion

            #region Chart

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                 "~/Scripts/Chart.min.js"
                 ));

            #endregion

            #region DataTable

            // dataTables 
            bundles.Add(new ScriptBundle("~/plugins/dataTables").Include(
                "~/Scripts/plugins/dataTables/datatables.min.js",
                "~/Scripts/plugins/dataTables/angular-datatables.min.js",
                "~/Scripts/plugins/dataTables/buttons/angular-datatables.buttons.min.js",
                "~/Scripts/plugins/dataTables/angular-datatables.bootstrap.min.js"));

            // dataTables css styles
            bundles.Add(new StyleBundle("~/Content/plugins/dataTables/dataTablesStyles").Include(
                "~/Scripts/plugins/dataTables/datatables.min.css",
                "~/Scripts/plugins/dataTables/angular-datatables.min.css",
                "~/Scripts/plugins/dataTables/datatables.bootstrap.min.css"));

            #endregion

        }

        private static void RegisterApp(BundleCollection bundles)
        {
            #region Modulo Conta

            bundles.Add(new ScriptBundle("~/bundles/contaMes").Include(
                "~/Scripts/app/ContaMesCTRL.js"));

            #endregion

          

        }
    }
}
