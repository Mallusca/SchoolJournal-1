namespace SchoolJournal.App_Start
{
    using System.Web;
    using System.Web.Optimization;
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/JournalPageScript").Include(
                        "~/Scripts/JournalPageScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/fonts/css/font-awesome.css", new CssRewriteUrlTransform()));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Content/site.css",
                    "~/Content/bootstrap.min.css",
                    "~/Content/bootstrap-theme.min.css",
                    "~/Content/form.css"
                ).Include("~/fonts/css/font-awesome.min.css", new CssRewriteUrlTransform()));

        }
    }
}