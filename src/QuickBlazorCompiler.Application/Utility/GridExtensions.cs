using QuickBlazorCompiler.Application.WebControls.Layout;
using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickBlazorCompiler.Application.Utility.ENUM;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class GridExtensions
    {
        public static GridRow WithColumn(this GridRow row, GridColumn column)
        {
            row.Columns.Add(column);
            return row;
        }

        public static GridRow WithColumns(this GridRow row, params GridColumn[] columns)
        {
            row.Columns.AddRange(columns);
            return row;
        }

        public static GridRow WithGutter(this GridRow row, string gutterSize)
        {
            row.CssClass += $" g-{gutterSize}";
            return row;
        }

        public static GridColumn WithSizeLg(this GridColumn column, ColumnSize size)
        {
            string val = size switch
            {
                ColumnSize.Full => "col-12",
                ColumnSize.Half => "col-lg-6",
                ColumnSize.Third => "col-lg-4",
                ColumnSize.Quarter => "col-lg-3",
                ColumnSize.Auto => "col",
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            };

            column.CssClass = val;
            return column;
        }

        public static GridColumn WithSizeMd(this GridColumn column, ColumnSize size)
        {
            string val = size switch
            {
                ColumnSize.Full => "col-md-12",
                ColumnSize.Half => "col-md-6",
                ColumnSize.Third => "col-md-4",
                ColumnSize.Quarter => "col-md-3",
                ColumnSize.Auto => "col",
                _ => throw new ArgumentOutOfRangeException(nameof(size), size, null)
            };

            column.CssClass = val;
            return column;
        }

        public static GridColumn WithContent(this GridColumn column, params WebControl[] content)
        {
            column.Children.AddRange(content);
            return column;
        }

        public static GridColumn Centered(this GridColumn column)
        {
            column.CssClass += " text-center";
            return column;
        }

        public static GridRow WithCssClass(this GridRow row, string cssClass)
        {
            row.CssClass = cssClass;
            return row;
        }

        public static GridColumn WithCssClass(this GridColumn column, string cssClass)
        {
            column.CssClass = cssClass;
            return column;
        }
    }
}
