﻿using System.Web;
using System.Web.Optimization;

namespace FileExtractor
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Libs/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Libs/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Libs/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                      "~/Scripts/Libs/bootstrap.js",
                      "~/Scripts/Libs/moment.js",
                      "~/Scripts/Libs/bootstrap-datepicker.js",
                      "~/Scripts/Libs/respond.js",
                      "~/Scripts/Libs/knockout-3.4.2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Css/bootstrap.css",
                      "~/Content/Css/ionicons.css",
                      "~/Content/Css/bootstrap-datepicker.css",
                      "~/Content/Css/site.css"));
        }
    }
}