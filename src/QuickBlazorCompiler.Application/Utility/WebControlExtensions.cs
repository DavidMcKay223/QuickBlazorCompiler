using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class WebControlExtensions
    {
        public static T WithId<T>(this T control, string Id) where T : WebControl
        {
            control.Id = Id;
            return control;
        }

        public static T WithCssClass<T>(this T control, string cssClass) where T : WebControl
        {
            control.CssClass = cssClass;
            return control;
        }

        public static InputControl WithBind(this InputControl control, string expression)
        {
            control.BindValueExpression = expression;
            return control;
        }

        public static InputControl WithPlaceholder(this InputControl control, string text)
        {
            control.Placeholder = text;
            return control;
        }
    }
}
