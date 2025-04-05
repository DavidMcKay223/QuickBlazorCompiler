using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class WebControlExtensions
    {
        public static Page AddControl(this Page page, WebControl child)
        {
            page.Controls.Add(child);
            return page;
        }

        public static Page AddControls(this Page page, params WebControl[] controls)
        {
            page.Controls.AddRange(controls);
            return page;
        }

        public static GridRow AddColumn(this GridRow row, GridColumn column)
        {
            row.Columns.Add(column);
            return row;
        }

        public static GridRow AddColumns(this GridRow row, params GridColumn[] columns)
        {
            row.Columns.AddRange(columns);
            return row;
        }

        public static GridColumn AddChild(this GridColumn column, WebControl child)
        {
            column.Add(child);
            return column;
        }

        public static GridColumn AddChildren(this GridColumn column, params WebControl[] children)
        {
            column.Children.AddRange(children);
            return column;
        }

        public static Card AddHeaderControl(this Card card, WebControl control)
        {
            card.HeaderControls.Add(control);
            return card;
        }

        public static Card AddHeaderControls(this Card card, params WebControl[] controls)
        {
            card.HeaderControls.AddRange(controls);
            return card;
        }

        public static Card AddBodyControl(this Card card, WebControl control)
        {
            card.BodyControls.Add(control);
            return card;
        }

        public static Card AddBodyControls(this Card card, params WebControl[] controls)
        {
            card.BodyControls.AddRange(controls);
            return card;
        }

        public static Card AddFooterControl(this Card card, WebControl control)
        {
            card.FooterControls.Add(control);
            return card;
        }

        public static Card AddFooterControls(this Card card, params WebControl[] controls)
        {
            card.FooterControls.AddRange(controls);
            return card;
        }

        public static Card Title(this Card card, string title)
        {
            card.Title = title;
            return card;
        }

        public static Card WithId(this Card card, string id)
        {
            card.Id = id;
            return card;
        }

        public static Button WithCssClass(this Button button, string cssClass)
        {
            button.CssClass = cssClass;
            return button;
        }

        public static Card WithCssClass(this Card card, string cssClass)
        {
            card.CssClass = cssClass;
            return card;
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

        public static Heading WithCssClass(this Heading heading, string cssClass)
        {
            heading.CssClass = cssClass;
            return heading;
        }

        public static T WithCssClass<T>(this T control, string cssClass) where T : WebControl
        {
            control.CssClass = cssClass;
            return control;
        }

        public static InputControl WithId(this InputControl control, string id)
        {
            control.Id = id;
            return control;
        }

        public static InputControl WithBind(this InputControl control, string expression)
        {
            control.BindValueExpression = expression;
            return control;
        }

        public static InputControl WithPlaceholder(this InputControl control, string text)
        {
            control.Placeholder = text;
            return control;
        }
    }

    public static class StyleExtensions
    {
        // Helper to get the CSS class (e.g., "btn-primary")
        public static string ToCssClass(this Style style, string prefix = "btn")
        {
            if (style == Style.None) return string.Empty;
            return $"{prefix}-{style.ToString().ToLowerInvariant()}";
        }
    }

    public static class InputTypeExtensions
    {
        public static string ToHtmlString(this InputType inputType)
        {
            // Handle potential casing issues if needed, but ToLowerInvariant is usually sufficient
            return inputType.ToString().ToLowerInvariant();
        }
    }
}
