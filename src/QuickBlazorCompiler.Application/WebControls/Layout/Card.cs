using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace QuickBlazorCompiler.Application.WebControls.Layout
{
    public class Card : WebControl
    {
        public List<WebControl> HeaderControls { get; } = new List<WebControl>();
        public List<WebControl> BodyControls { get; } = new List<WebControl>();
        public List<WebControl> FooterControls { get; } = new List<WebControl>();

        // Optional simple Title property - adds an <h5> to the header
        public string? Title { get; set; }

        public Card()
        {
            // Default card class
            CssClass = "card";
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            var innerIndent = GetIndent(indentLevel + 1);
            var contentIndent = GetIndent(indentLevel + 2);
            var sb = new StringBuilder();

            sb.AppendLine($"{indent}<div{GetAttributes()}>"); // Main card div

            // --- Header ---
            // Render header only if there's a Title or explicit HeaderControls
            bool hasHeaderContent = !string.IsNullOrWhiteSpace(Title) || HeaderControls.Any();
            if (hasHeaderContent)
            {
                sb.AppendLine($"{innerIndent}<div class=\"card-header\">"); // Header div
                if (!string.IsNullOrWhiteSpace(Title))
                {
                    // Render the simple title if provided
                    sb.AppendLine($"{contentIndent}<h5 class=\"card-title\">{Title}</h5>");
                }
                // Render any custom header controls
                sb.Append(RenderChildren(HeaderControls, indentLevel + 2));
                sb.AppendLine($"{innerIndent}</div>"); // Close card-header
            }

            // --- Body ---
            // Render body only if there are BodyControls
            if (BodyControls.Any())
            {
                sb.AppendLine($"{innerIndent}<div class=\"card-body\">"); // Body div
                sb.Append(RenderChildren(BodyControls, indentLevel + 2));
                sb.AppendLine($"{innerIndent}</div>"); // Close card-body
            }
            else
            {
                // Add an empty body if there's no header or footer?
                // Or follow Bootstrap: if no body, it just doesn't render.
                // Let's stick to not rendering if empty.
            }


            // --- Footer ---
            // Render footer only if there are FooterControls
            if (FooterControls.Any())
            {
                sb.AppendLine($"{innerIndent}<div class=\"card-footer\">"); // Footer div
                sb.Append(RenderChildren(FooterControls, indentLevel + 2));
                sb.AppendLine($"{innerIndent}</div>"); // Close card-footer
            }

            sb.AppendLine($"{indent}</div>"); // Close main card div

            return sb.ToString();
        }
    }
}
