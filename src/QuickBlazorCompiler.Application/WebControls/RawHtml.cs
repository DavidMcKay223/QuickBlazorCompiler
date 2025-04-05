using System;
using System.Text;

namespace QuickBlazorCompiler.Application.WebControls
{
    public class RawHtml : WebControl
    {
        public string HtmlContent { get; set; }

        public RawHtml(string htmlContent = "")
        {
            HtmlContent = htmlContent;
            CssClass = null;
            Id = null;
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            // Render the raw HTML, potentially indented
            // Be careful with indentation here, as it might affect inline elements
            // Often, raw HTML is best rendered without extra leading whitespace.
            return $"{GetIndent(indentLevel)}{HtmlContent}{Environment.NewLine}";
        }
    }
}
