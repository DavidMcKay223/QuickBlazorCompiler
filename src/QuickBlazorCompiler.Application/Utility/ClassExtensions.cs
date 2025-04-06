using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class StyleExtensions
    {
        // Helper to get the CSS class (e.g., "btn-primary")
        public static string ToCssClass(this Style style, string prefix = "btn")
        {
            if (style == Style.None) return string.Empty;
            return $"{prefix}-{style.ToString().ToLowerInvariant()}";
        }
    }

    public static class InputTypeExtensions
    {
        public static string ToHtmlString(this InputType inputType)
        {
            // Handle potential casing issues if needed, but ToLowerInvariant is usually sufficient
            return inputType.ToString().ToLowerInvariant();
        }
    }
}
