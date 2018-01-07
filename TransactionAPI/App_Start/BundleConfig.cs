using System.Web.Optimization;

namespace TransactionAPI
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/sbadmin").Include(
			"~/Scripts/bootstrap.bundle.min.js",
			"~/Scripts/jquery.easing.min.js",
			"~/Scripts/Chart.min.js",
			"~/Scripts/jquery.dataTables.js",
			"~/Scripts/dataTables.bootstrap4.js",
			"~/Scripts/sb-admin.min.js",
			"~/Scripts/sb-admin-datatables.min.js",
			"~/Scripts/sb-admin-charts.min.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
				  "~/Scripts/bootstrap.js",
				  "~/Scripts/datatables/jquery.dataTables.js",
				  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.min.css",
					  "~/Content/font-awesome/font-awesome.min.css",
					  "~/Content/datatables/dataTables.bootstrap4.css",
					  "~/Content/Site.css",
					  "~/Content/sb-admin.css"));
		}
	}
}
