using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.WebControls
{
    public abstract class WebControl
    {
        public string CssClass { get; set; }
        public List<WebControl> Children { get; } = new List<WebControl>();

        public virtual string GenerateHtml()
        {
            var sb = new StringBuilder();
            sb.Append($"<div class=\"{CssClass}\">");
            foreach (var child in Children)
            {
                sb.Append(child.GenerateHtml());
            }
            sb.Append("</div>");
            return sb.ToString();
        }
    }
}
