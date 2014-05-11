using System.Web.Optimization;

namespace BJ.MongoDB.WebUI
{
    public class BundleConfig
    {
        // Дополнительные сведения о Bundling см. по адресу http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            ///////////////////////////////////////////////////////////////////////////////////
            // JavaScript
            //
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").
                Include("~/Scripts/bootstrap.js",
                    "~/Scripts/bootstrap-datepicker.js",
                    "~/Scripts/bootstrap-tokenfield.js",
                    "~/Scripts/locales/bootstrap-datepicker.ru.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            ///////////////////////////////////////////////////////////////////////////////////
            // CSS
            //
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/Site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/base").
                Include("~/Content/bootstrap/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/theme").
                Include("~/Content/bootstrap/bootstrap-theme.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap/addons").
                Include("~/Content/bootstrap/bootstrap-tokenfield.css",
                        "~/Content/bootstrap/bootstrap-datepicker.css"));

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
        }
    }
}