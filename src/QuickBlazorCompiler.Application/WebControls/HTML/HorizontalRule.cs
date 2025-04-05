using System;
using System.Text;

namespace QuickBlazorCompiler.Application.WebControls.HTML
{
    public class HorizontalRule : WebControl
    {
        public HorizontalRule() { } // No content needed

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            // Allow applying classes/styles directly to the hr element
            var attributes = GetAttributes();
            return $"{indent}<hr{attributes} />{Environment.NewLine}";
        }
    }
}