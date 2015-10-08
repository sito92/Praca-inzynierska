using System.Web;
using System.Web.Optimization;

namespace AdminPanel
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/Globals/Events.js",               
                       "~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-ui").Include(
                       "~/Scripts/angular-ui/ui-bootstrap-tpls.js"));

            bundles.Add(new ScriptBundle("~/bundles/appModule").Include(
                       "~/Scripts/Modules/AppModule.js",
                       "~/Scripts/Directives/LoaderDirective.js",
                       "~/Scripts/Interceptors/HttpInterceptor.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/site.css",
                 "~/Content/Styles.css",
                "~/Content/bootstrap.css",
                 "~/Content/bootstrap-theme.css",
                 "~/Content/simple-sidebar.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/leftMenu").Include(
                      "~/Scripts/Controllers/LeftMenuController.js"));

            bundles.Add(new ScriptBundle("~/bundles/newsModule").Include(
                      "~/Scripts/Controllers/NewsController.js",
                      "~/Scripts/Directives/InsetDirective.js",
                      "~/Scripts/Directives/InsetController.js",
                      "~/Scripts/Services/InsetService.js",
                      "~/Scripts/Services/PageService.js",
                      "~/Scripts/Services/FileService.js",
                      "~/Scripts/Controllers/InsetPartsControllers/ExternalLinkController.js",
                      "~/Scripts/Controllers/InsetPartsControllers/LocalLinkController.js",
                      "~/Scripts/Controllers/InsetPartsControllers/ImagesController.js",
                      "~/Scripts/Directives/InsetArgument.js",
                      "~/Scripts/Directives/Pickers/LocalLinkPicker.js",
                      "~/Scripts/Directives/Pickers/ImagesPicker.js"
                      ));



        }
    }
}