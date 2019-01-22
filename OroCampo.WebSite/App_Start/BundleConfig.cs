using System.Web.Optimization;

namespace OroCampo.WebSite
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.2.4.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/Site.css"));

            bundles.Add(
                new StyleBundle("~/Content/texteditorcss").Include(
                    "~/Content/TextEditor/froala_editor.css",
                    "~/Content/TextEditor/froala_style.css",
                    "~/Content/TextEditor/code_view.css",
                    "~/Content/TextEditor/code_view.min.css",
                    "~/Content/TextEditor/emoticons.css",
                    "~/Content/TextEditor/fullscreen.css",
                    "~/Content/TextEditor/special_characters.css",
                    "~/Content/TextEditor/colors.css"));

            bundles.Add(
                new ScriptBundle("~/bundles/texteditorjs").Include(
                    "~/Scripts/TextEditor/froala_editor.min.js",
                    "~/Scripts/TextEditor/plugins/align.min.js",
                    "~/Scripts/TextEditor/plugins/code_beautifier.min.js",
                    "~/Scripts/TextEditor/plugins/code_view.min.js",
                    "~/Scripts/TextEditor/plugins/draggable.min.js",
                    "~/Scripts/TextEditor/plugins/entities.min.js",
                    "~/Scripts/TextEditor/plugins/link.min.js",
                    "~/Scripts/TextEditor/plugins/lists.min.js",
                    "~/Scripts/TextEditor/plugins/paragraph_format.min.js",
                    "~/Scripts/TextEditor/plugins/paragraph_style.min.js",
                    "~/Scripts/TextEditor/plugins/url.min.js",
                    "~/Scripts/TextEditor/plugins/colors.min.js",
                    "~/Scripts/TextEditor/plugins/emoticons.min.js",
                    "~/Scripts/TextEditor/plugins/font_family.min.js",
                    "~/Scripts/TextEditor/plugins/font_size.min.js",
                    "~/Scripts/TextEditor/plugins/fullscreen.min.js",
                    "~/Scripts/TextEditor/plugins/special_characters.min.js",
                    "~/Scripts/TextEditor/yolo.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/buttonchoosefilejs").Include("~/Scripts/ButtonChooseFile/button.js"));

            bundles.Add(new ScriptBundle("~/bundles/sitequery").Include("~/Scripts/site.js"));

            bundles.Add(
                new ScriptBundle("~/bundles/theme").Include(
                    "~/Themes/js/bootstrap.min.js",
                    "~/Theme/vendors/revolution/js/jquery.themepunch.tools.min.js",
                    "~/Theme/vendors/revolution/js/jquery.themepunch.revolution.min.js",
                    "~/Theme/vendors/revolution/js/extensions/revolution.extension.video.min.js",
                    "~/Theme/vendors/revolution/js/extensions/revolution.extension.slideanims.min.js",
                    "~/Theme/vendors/revolution/js/extensions/revolution.extension.layeranimation.min.js",
                    "~/Theme/vendors/revolution/js/extensions/revolution.extension.navigation.min.js",
                    "~/Theme/vendors/owl-carousel/owl.carousel.min.js",
                    "~/Theme/vendors/isotope/imagesloaded.pkgd.min.js",
                    "~/Theme/vendors/isotope/isotope.pkgd.min.js",
                    "~/Theme/vendors/magnific-popup/jquery.magnific-popup.min.js",
                    "~/Theme/js/jquery.fancybox.pack.js",
                    "~/Theme/js/jquery.mixitup.min.js",
                    "~/Theme/js/gallery.js",
                    "~/Theme/js/theme.js"));

            bundles.Add(
                new StyleBundle("~/Content/theme").Include(
                    "~/Theme/vendors/revolution/css/settings.css",
                    "~/Theme/vendors/revolution/css/layers.css",
                    "~/Theme/vendors/revolution/css/navigation.css",
                    "~/Theme/vendors/animate-css/animate.css",
                    "~/Theme/vendors/owl-carousel/assets/owl.carousel.min.css",
                    "~/Theme/vendors/magnific-popup/magnific-popup.css",
                    "~/Theme/vendors/stroke-icon/style.css",
                    "~/Theme/css/font-awesome.css",
                    "~/Theme/css/style.css",
                    "~/Theme/css/responsive.css",
                    "~/Theme/css/responsive2.css"));
        }
    }
}