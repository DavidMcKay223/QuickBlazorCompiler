using System;
using System.Text;

namespace QuickBlazorCompiler.Application.WebControls.HTML
{
    public class Label : WebControl // Inherit from your base class
    {
        public string Text { get; set; }
        public string? ForId { get; set; } // Links label to input ID

        public Label(string text = "", string? forId = null)
        {
            Text = text;
            ForId = forId;
            CssClass = "form-label"; // Common Bootstrap class
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            var sb = new StringBuilder();
            sb.Append($"{indent}<label");
            // Include base attributes first (like custom classes on the label itself)
            sb.Append(GetAttributes());
            if (!string.IsNullOrWhiteSpace(ForId))
            {
                sb.Append($" for=\"{ForId}\"");
            }
            sb.Append($">{Text}</label>{Environment.NewLine}");
            return sb.ToString();
        }
    }
}
