using System.Web;
using System.Web.Optimization;

namespace PhoneCat
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-resource.js",
                        "~/Scripts/ng-file-upload.js"
                        ));
            bundles.Add(new ScriptBundle("~/bundles/appModules").Include(
                        "~/app/app.module.js",
                        "~/app/app.config.js",
                        "~/app/core/core.module.js",
                        "~/app/core/phone/phone.module.js",
                        "~/app/core/phone/phone.service.js",
                        "~/app/core/android-os/android-os.module.js",
                        "~/app/core/android-os/android-os.service.js",
                        "~/app/core/android-ui/android-ui.module.js",
                        "~/app/core/android-ui/android-ui.service.js",
                        "~/app/core/battery-type/battery-type.module.js",
                        "~/app/core/battery-type/battery-type.service.js",
                        "~/app/core/availability/availability.module.js",
                        "~/app/core/availability/availability.service.js",
                        "~/app/phone-list/phone-list.module.js",
                        "~/app/phone-list/phone-list.component.js",
                        "~/app/phone-detail/phone-detail.module.js",
                        "~/app/phone-detail/phone-detail.component.js",
                        "~/app/phone-edit/phone-edit.module.js",
                        "~/app/phone-edit/phone-edit.component.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
