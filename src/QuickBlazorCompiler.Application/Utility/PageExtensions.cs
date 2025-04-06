using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class PageExtensions
    {
        public static Page AddComponent(this Page page, WebControl component)
        {
            page.Controls.Add(component);
            return page;
        }

        public static Page AddComponents(this Page page, params WebControl[] components)
        {
            page.Controls.AddRange(components);
            return page;
        }
    }
}
