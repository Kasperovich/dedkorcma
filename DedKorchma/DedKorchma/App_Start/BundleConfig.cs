using System.Web;
using System.Web.Optimization;

namespace DedKorchma
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap/bootstrap.js",
                "~/Scripts/bootstrap/bootstrap-datetimepicker.js",
                 "~/Scripts/bootstrap/bootstrap-datetimepicker.min.js",
                 "~/Scripts/bootstrap/bootstrap.min.js",
                "~/Scripts/respond.js",
                "~/Scripts/moment.js",
                "~/Scripts/moment-with-locales.js",
                "~/Scripts/moment-with-locales.min.js"));

            bundles.Add(new StyleBundle("~/bundles/style").Include(
                "~/Content/css/bootstrap-datetimepicker.css",
                "~/Content/css/bootstrap-datetimepicker.min.css",
                "~/Content/css/bootstrap.min.css",
                "~/Content/css/fonts.css",
                "~/Content/css/style.css",
                "~/Content/css/animate.css",
                "~/Content/css/media.css"));
        }
    }
}