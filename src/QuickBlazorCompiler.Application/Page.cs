using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application
{
    public class Page
    {
        public string FilePath { get; }
        public List<WebControl> Controls { get; set; } = new List<WebControl>();

        public Page(string filePath)
        {
            FilePath = filePath;
        }

        public void Add(WebControl control)
        {
            Controls.Add(control);
        }

        public string GenerateHtml()
        {
            var sb = new StringBuilder();
            foreach (var control in Controls)
            {
                sb.Append(control.GenerateHtml());
            }
            return sb.ToString();
        }

        public void SaveToFile()
        {
            System.IO.File.WriteAllText(FilePath, GenerateHtml());
        }
    }
}
