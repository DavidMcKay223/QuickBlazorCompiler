using System;
using System.Text;

namespace QuickBlazorCompiler.Application.WebControls.HTML
{
    public class Heading : WebControl
    {
        public int Level { get; set; } // 1 to 6
        public string Text { get; set; }

        public Heading(int level, string text = "")
        {
            if (level < 1 || level > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(level), "Heading level must be between 1 and 6.");
            }
            Level = level;
            Text = text; // Note: Text can still contain simple inline HTML like <strong>
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            var tagName = $"h{Level}";
            // Allow applying classes/styles directly to the heading
            var attributes = GetAttributes();

            return $"{indent}<{tagName}{attributes}>{Text}</{tagName}>{Environment.NewLine}";
        }
    }
}
