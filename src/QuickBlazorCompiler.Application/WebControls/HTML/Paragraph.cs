using System;
using System.Text;

namespace QuickBlazorCompiler.Application.WebControls.HTML
{
    public class Paragraph : WebControl
    {
        public string Text { get; set; }

        public Paragraph(string text = "")
        {
            Text = text; // Note: Text can still contain simple inline HTML like <strong>
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            // Allow applying classes/styles directly to the paragraph
            var attributes = GetAttributes();

            return $"{indent}<p{attributes}>{Text}</p>{Environment.NewLine}";
        }
    }
}
