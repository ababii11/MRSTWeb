using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MRSTWeb.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // CSS Bundles
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/animate.min.css",
                "~/Content/bootstrap.min.css",
                "~/Content/flaticon.min.css",
                "~/Content/font-awesome.css",
                "~/Content/gijgo.css",
                "~/Content/magnific-popup.css",
                "~/Content/nice-select.css",
                "~/Content/owl.carousel.min.css",
                "~/Content/slick.css",
                "~/Content/slicknav.css",
                "~/Content/style.css",          // lipseau ghilimelele
                "~/Content/theme-default.css",
                "~/Content/themify-icons.css"
            ));

            // JS Bundles
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                "~/Scripts/vendor/jquery-1.12.4.min.js",
                "~/Scripts/vendor/modernizr-3.5.0.min.js",
                "~/Scripts/vendor/popper.min.js",
                "~/Scripts/vendor/bootstrap.min.js",
                "~/Scripts/vendor/owl.carousel.min.js",
                "~/Scripts/vendor/slick.min.js",
                "~/Scripts/vendor/isotope.pkgd.min.js",
                "~/Scripts/vendor/imagesloaded.pkgd.min.js",
                "~/Scripts/vendor/jquery.magnific-popup.min.js",
                "~/Scripts/vendor/jquery.ajaxchimp.min.js",
                "~/Scripts/vendor/jquery.counterup.js",
                "~/Scripts/vendor/jquery.form.js",
                "~/Scripts/vendor/jquery.scrollUp.min.js",
                "~/Scripts/vendor/jquery.slicknav.min.js",
                "~/Scripts/vendor/jquery.validate.min.js",
                "~/Scripts/vendor/waypoints.min.js",
                "~/Scripts/vendor/wow.min.js",
                "~/Scripts/vendor/gigjo.min.js",
                "~/Scripts/vendor/plugins.js",
                "~/Scripts/vendor/contact.js",
                "~/Scripts/vendor/mail-script.js", // dacă există
                "~/Scripts/vendor/nice-select.min.js",
                "~/Scripts/vendor/ajax-form.js",
                "~/Scripts/vendor/scrollIt.js",
                // adaugă oricare alte fișiere JS pe care le ai în /vendor
                "~/Scripts/vendor/main.js"
            ));

            // (Opțional) Activare optimizări în mod producție:
            // BundleTable.EnableOptimizations = true;
        }
    }
}
