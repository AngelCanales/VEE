using System.Web;
using System.Web.Optimization;

namespace VEE
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Scripts/").Include(
                  
                    // "~/Scripts/plugins/jquery/jquery.min.js",
                    //"~/Scripts/plugins/bootstrap/js/bootstrap.bundle.min.js",
                    //"~/Scripts/plugins/chartjs-old/Chart.min.js",
                    //"~/Scripts/plugins/fastclick/fastclick.js",
                    //"~/Scripts/plugins/morris/morris.min.js",
                    //"~/Scripts/plugins/sparkline/jquery.sparkline.min.js",
                    //"~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.min.js",
                    //"~/Scripts/plugins/jvectormap/jquery-jvectormap-world-mill-en.js",
                    //"~/Scripts/plugins/knob/jquery.knob.js",
                    //"~/Scripts/plugins/daterangepicker/daterangepicker.js",
                    //"~/Scripts/plugins/datepicker/bootstrap-datepicker.js",
                    //"~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js",
                    //"~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js",
                    //"~/Scripts/plugins/fastclick/fastclick.js",
                    //"~/Scripts/dist/js/adminlte.js",
                    //"~/Scripts/dist/js/pages/dashboard.js",
                    //"~/Scripts/dist/js/demo.js",
                    //"~/Scripts/plugins/flot/jquery.flot.min.js",
                    //"~/Scripts/plugins/flot/jquery.flot.resize.min.js",
                    //"~/Scripts/plugins/flot/jquery.flot.pie.min.js",
                    //"~/Scripts/plugins/flot/jquery.flot.categories.min.js"
                    ));

                                       bundles.Add(new StyleBundle("~/Scripts").Include(
                      
                     // "~/Scripts/plugins/font-awesome/css/font-awesome.min.css",
                     // "~/Scripts/dist/css/adminlte.min.css",
                     // "~/Scripts/plugins/iCheck/flat/blue.css",
                     // "~/Scripts/plugins/morris/morris.css",
                     // "~/Scripts/plugins/jvectormap/jquery-jvectormap-1.2.2.css",
                     // "~/Scripts/plugins/datepicker/datepicker3.css",
                     // "~/Scripts/plugins/daterangepicker/daterangepicker-bs3.css"
                     //, "~/Scripts/plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"
                      ));
   
         

        }
    }
}
