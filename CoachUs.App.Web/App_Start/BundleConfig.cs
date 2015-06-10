using System.Web;
using System.Web.Optimization;

namespace CoachUs.App.Web
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

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/more-jquery").Include(
                        "~/Scripts/jquery-ui.custom.js",
                        "~/Scripts/jquery.ui.touch-punch.js",
                        "~/Scripts/jquery.easypiechart.js",
                        "~/Scripts/jquery.sparkline.js",
                        "~/Scripts/flot/jquery.flot.js",
                        "~/Scripts/flot/jquery.flot.pie.js",
                        "~/Scripts/flot/jquery.flot.resize.js"));

            bundles.Add(new ScriptBundle("~/bundles/ace").Include(
                        "~/Scripts/ace/elements.scroller.js",
                        "~/Scripts/ace/elements.colorpicker.js",
                        "~/Scripts/ace/elements.fileinput.js",
                        "~/Scripts/ace/elements.typeahead.js",
                        "~/Scripts/ace/elements.wysiwyg.js",
                        "~/Scripts/ace/elements.spinner.js",
                        "~/Scripts/ace/elements.treeview.js",
                        "~/Scripts/ace/elements.wizard.js",
                        "~/Scripts/ace/elements.aside.js",
                        "~/Scripts/ace/ace.js",
                        "~/Scripts/ace/ace.ajax-content.js",
                        "~/Scripts/ace/ace.touch-drag.js",
                        "~/Scripts/ace/ace.sidebar.js",
                        "~/Scripts/ace/ace.sidebar-scroll-1.js",
                        "~/Scripts/ace/ace.submenu-hover.js",
                        "~/Scripts/ace/ace.widget-box.js",
                        "~/Scripts/ace/ace.settings.js",
                        "~/Scripts/ace/ace.settings-rtl.js",
                        "~/Scripts/ace/ace.settings-skin.js",
                        "~/Scripts/ace/ace.widget-on-reload.js",
                        "~/Scripts/ace/ace.searchbox-autocomplete.js"));

            bundles.Add(new ScriptBundle("~/bundles/ace-extra").Include(
                        "~/Scripts/ace-extra.js"));

            bundles.Add(new ScriptBundle("~/bundles/login").Include(
                        "~/Scripts/knockout-{version}.js",
                        "~/Scripts/knockout.validation.js",
                        "~/Scripts/app/coachus-api.js",
                        "~/Scripts/app/views/login.js"));

            bundles.Add(new StyleBundle("~/Content/bootstrap-css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/site").Include(
                        "~/Content/site.css"));
        }
    }
}
