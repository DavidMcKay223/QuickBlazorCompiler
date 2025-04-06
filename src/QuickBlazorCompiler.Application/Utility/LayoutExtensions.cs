using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class LayoutExtensions
    {
        public static T WithMargins<T>(this T control, string margins) where T : WebControl
        {
            control.CssClass += $" m-{margins}";
            return control;
        }

        public static T WithPadding<T>(this T control, string padding) where T : WebControl
        {
            control.CssClass += $" p-{padding}";
            return control;
        }

        public static T Centered<T>(this T control) where T : WebControl
        {
            control.CssClass += " mx-auto";
            return control;
        }
    }
}
