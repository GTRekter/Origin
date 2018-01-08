using System.Web;
using System.Web.Optimization;

namespace Origin
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Content/Scripts/Libs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Content/Scripts/Libs/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/Scripts/Libs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                      "~/Content/Scripts/Libs/bootstrap.js",
                      "~/Content/Scripts/Libs/moment.js",
                      "~/Content/Scripts/Libs/bootstrap-datepicker.js",
                      "~/Content/Scripts/Libs/respond.js",
                      "~/Content/Scripts/Libs/knockout-3.4.2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/Css/ionicons.css",
                      "~/Content/Css/bootstrap-datepicker.css",
                      "~/Content/Css/site.css"));
        }
    }
}
