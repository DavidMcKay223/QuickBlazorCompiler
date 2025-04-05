using System;
using System.Text;
using QuickBlazorCompiler.Application.Utility;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;

namespace QuickBlazorCompiler.Application.WebControls.HTML
{
    public class Button : WebControl
    {
        public string Text { get; set; }
        public string Type { get; set; } // "button", "submit", "reset"
        public Bootstrap.Style BootstrapStyle { get; set; }

        // Add other common button attributes if needed (e.g., IsDisabled, OnClick handler name)
        // public bool IsDisabled { get; set; }
        // public string OnClick { get; set; } // For Blazor event handlers later?

        public Button(string text = "", Bootstrap.Style style = Bootstrap.Style.Secondary, string type = "button")
        {
            Text = text;
            Type = type;
            BootstrapStyle = style;
            // Base class CssClass will hold additional custom classes.
            // We'll combine them with the Bootstrap style class.
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            var styleClass = BootstrapStyle.ToCssClass("btn"); // Get "btn-primary" etc.
            var combinedClasses = $"btn {styleClass} {CssClass}".Trim(); // Combine base, style, and custom classes

            var sb = new StringBuilder();
            sb.Append($"{indent}<button type=\"{Type}\"");

            // Use helper, but manage class attribute specially
            if (!string.IsNullOrWhiteSpace(Id)) sb.Append($" id=\"{Id}\"");
            if (!string.IsNullOrWhiteSpace(combinedClasses)) sb.Append($" class=\"{combinedClasses}\"");
            if (!string.IsNullOrWhiteSpace(Style)) sb.Append($" style=\"{Style}\"");
            // Add other attributes like 'disabled' if needed
            // if (IsDisabled) sb.Append(" disabled");
            // if (!string.IsNullOrWhiteSpace(OnClick)) sb.Append($" @onclick=\"{OnClick}\""); // Example for Blazor

            sb.Append($">{Text}</button>{Environment.NewLine}");

            return sb.ToString();
        }
    }
}
