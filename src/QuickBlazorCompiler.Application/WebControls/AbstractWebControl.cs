using System.Text;
using System.Collections.Generic;

namespace QuickBlazorCompiler.Application.WebControls
{
    public abstract class WebControl
    {
        public string? Id { get; set; }
        public string? CssClass { get; set; }
        public string? Style { get; set; }

        public abstract string GenerateHtml(int indentLevel = 0);

        protected string GetIndent(int level) => new string(' ', level * 4);

        protected string GetAttributes()
        {
            var sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(Id)) sb.Append($" id=\"{Id}\"");
            if (!string.IsNullOrWhiteSpace(CssClass)) sb.Append($" class=\"{CssClass}\"");
            if (!string.IsNullOrWhiteSpace(Style)) sb.Append($" style=\"{Style}\"");
            return sb.ToString();
        }

        // Keep this helper if controls like GridColumn use it
        protected string RenderChildren(List<WebControl> children, int indentLevel)
        {
            var sb = new StringBuilder();
            foreach (var child in children)
            {
                sb.Append(child.GenerateHtml(indentLevel));
            }
            return sb.ToString();
        }
    }

    public class WebControlGroup : WebControl
    {
        public List<WebControl> Children { get; }

        public WebControlGroup(List<WebControl> children)
        {
            Children = children;
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            return RenderChildren(Children, indentLevel);
        }
    }
}
