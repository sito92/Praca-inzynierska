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
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/moment.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                                "~/Scripts/calendar/*.js"));

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
                "~/Content/bootstrap.css",
                 "~/Content/simple-sidebar.css",
                 "~/Content/fullcalendar.css",
                 "~/Content/calendarDemo.css",
                 "~/Content/textAngular.css",
                 "~/Content/Styles.css",
                 "~/Content/angular-ui-tree.css",
                  "~/Content/font-awesome/css/font-awesome.css"
                ));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new ScriptBundle("~/bundles/leftMenu").Include(
                      "~/Scripts/Controllers/LeftMenuController.js"));

            bundles.Add(new ScriptBundle("~/bundles/news").Include(
                      "~/Scripts/Controllers/NewsController.js",
                      "~/Scripts/Directives/InsetDirective.js",
                      "~/Scripts/Directives/InsetController.js",
                      "~/Scripts/Services/InsetService.js",
                      "~/Scripts/Services/PageService.js",
                      "~/Scripts/Services/FileService.js",
                      "~/Scripts/Services/NewsService.js",
                      "~/Scripts/Services/NewsCategoriesService.js",
                      "~/Scripts/Controllers/InsetPartsControllers/ExternalLinkController.js",
                      "~/Scripts/Controllers/InsetPartsControllers/LocalLinkController.js",
                      "~/Scripts/Controllers/InsetPartsControllers/ImagesController.js",
                      "~/Scripts/Directives/InsetArgument.js",
                      "~/Scripts/Directives/Pickers/LocalLinkPicker.js",
                      "~/Scripts/Directives/Pickers/ImagesPicker.js",
                      "~/Scripts/TextAngularTools/InsetTool.js",
                      "~/Scripts/Modules/InsetModule.js"

                      ));
            bundles.Add(new ScriptBundle("~/bundles/serviceProvider").Include(
                    "~/Scripts/Controllers/ServiceProviderController.js",
                    "~/Scripts/Services/ServiceProviderService.js",
                    "~/Scripts/Services/ServiceTypeService.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/serviceType").Include(
                     "~/Scripts/Controllers/ServiceTypeController.js",
                     "~/Scripts/Services/ServiceTypeService.js"
                     ));
            bundles.Add(new ScriptBundle("~/bundles/pages").Include(
                    "~/Scripts/Controllers/PageController.js",
                    "~/Scripts/Services/PageService.js",
                    "~/Scripts/Controllers/InsetPartsControllers/ExternalLinkController.js",
                    "~/Scripts/Controllers/InsetPartsControllers/LocalLinkController.js",
                    "~/Scripts/Controllers/InsetPartsControllers/ImagesController.js",
                    "~/Scripts/Directives/InsetArgument.js",
                    "~/Scripts/Directives/Pickers/LocalLinkPicker.js",
                    "~/Scripts/Directives/Pickers/ImagesPicker.js",
                    "~/Scripts/TextAngularTools/InsetTool.js",
                    "~/Scripts/Modules/InsetModule.js",
                     "~/Scripts/Directives/InsetDirective.js",
                      "~/Scripts/Directives/InsetController.js",
                      "~/Scripts/Services/InsetService.js",
                      "~/Scripts/Services/FileService.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/services").Include(
                   "~/Scripts/Controllers/ServicesController.js",
                    "~/Scripts/Services/ServicesService.js",
                    "~/Scripts/Services/ServiceProviderService.js",
                    "~/Scripts/Services/ServiceTypeService.js"
                   ));
            bundles.Add(new ScriptBundle("~/bundles/menuButton").Include(
                    "~/Scripts/Controllers/MenuButtonController.js",
                    "~/Scripts/Services/MenuButtonService.js",
                    "~/Scripts/Services/PageService.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/files").Include(
                    "~/Scripts/Controllers/FileController.js",
                    "~/Scripts/Services/FileService.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/angular-drag-and-drop").Include(
                    "~/Scripts/angular-drag-and-drop-lists.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/text-angular").Include(
                   "~/Scripts/text-angular/textAngular-rangy.js",
                   "~/Scripts/text-angular/textAngular-sanitize.js",
                   "~/Scripts/text-angular/textAngularSetup.js",
                   "~/Scripts/text-angular/textAngular.js"
                   ));
            bundles.Add(new ScriptBundle("~/bundles/angular-file-upload").Include(
                    "~/Scripts/angular-file-upload.js"
                    ));
            bundles.Add(new ScriptBundle("~/bundles/angular-ui-tree").Include(
                   "~/Scripts/angular-ui-tree.js"
                   ));
            bundles.Add(new ScriptBundle("~/bundles/filters").Include(
                  "~/Scripts/Filters/*.js"
                  ));
            bundles.Add(new ScriptBundle("~/bundles/settings").Include(
                  "~/Scripts/Controllers/SettingsController.js",
                    "~/Scripts/Services/SettingsService.js"
                  ));



        }
    }
}