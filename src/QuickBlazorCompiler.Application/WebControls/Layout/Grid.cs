using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace QuickBlazorCompiler.Application.WebControls.Layout
{
    // Represents a Bootstrap Row
    public class GridRow : WebControl
    {
        public List<GridColumn> Columns { get; } = new List<GridColumn>();

        public GridRow()
        {
            CssClass = "row"; // Default to Bootstrap row
        }

        public void AddColumn(GridColumn column)
        {
            Columns.Add(column);
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            if (!Columns.Any()) return string.Empty; // Don't render empty rows

            var indent = GetIndent(indentLevel);
            var sb = new StringBuilder();

            sb.AppendLine($"{indent}<div{GetAttributes()}>"); // Row div
            foreach (var col in Columns)
            {
                sb.Append(col.GenerateHtml(indentLevel + 1)); // Render columns
            }
            sb.AppendLine($"{indent}</div>"); // Close row div

            return sb.ToString();
        }
    }

    // Represents a Bootstrap Column
    public class GridColumn : WebControl
    {
        public List<WebControl> Children { get; } = new List<WebControl>();

        // Constructor allows setting column classes like "col-md-4"
        public GridColumn(string columnClasses = "col")
        {
            CssClass = columnClasses;
        }

        public void Add(WebControl control)
        {
            Children.Add(control);
        }


        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            var sb = new StringBuilder();

            sb.AppendLine($"{indent}<div{GetAttributes()}>"); // Column div
            sb.Append(RenderChildren(Children, indentLevel + 1)); // Render controls inside column
            sb.AppendLine($"{indent}</div>"); // Close column div

            return sb.ToString();
        }
    }
}
