using System.Web;
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

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/datatables/jquery.dataTables.js",
					  "~/Scripts/respond.js"));

			/* todo: may need more
			 * 
			 * 
	<link rel="stylesheet" href="~/lib/bootstrap/dist/css/bootstrap.css" />
	<link rel="stylesheet" href="~/css/site.css" />
	<!-- Bootstrap core CSS-->
	<link rel="stylesheet" href="~/vendor/bootstrap/css/bootstrap.min.css">
	<!-- Custom fonts for this template-->
	<link rel="stylesheet" href="~/vendor/font-awesome/css/font-awesome.min.css" type="text/css">
*/

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/sb-admin.css",
					  "~/Content/datatables/dataTables.bootstrap4.css",
					  "~/Content/font-awesome/font-awesome.min.css",
					  "~/Content/Site.css"));
		}
	}
}
