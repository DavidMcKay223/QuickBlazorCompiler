using QuickBlazorCompiler.Application.WebControls.Bootstrap;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application
{
    public static class UI
    {
        public static Page Page(string filename, params WebControl[] content)
            => new Page(filename) { Controls = new List<WebControl>(content) };

        public static Heading Heading(int level, string text, string cssClass = null)
            => new Heading(level, text) { CssClass = cssClass };

        public static Paragraph Paragraph(string html)
            => new Paragraph(html);

        public static HorizontalRule HR()
            => new HorizontalRule();

        public static GridRow GridRow(string cssClass = "row g-3", params GridColumn[] columns)
            => new GridRow() { CssClass = cssClass, Columns = new List<GridColumn>(columns) };

        public static GridColumn GridColumn(string cssClass, params WebControl[] children)
            => new GridColumn(cssClass) { Children = new List<WebControl>(children) };

        public static Card Card(string id = null, string title = null, WebControl header = null, WebControl body = null, WebControl footer = null)
        {
            var card = new Card() { Id = id, Title = title };
            if (header != null) card.HeaderControls.Add(header);
            if (body != null)
            {
                if (body is WebControlGroup group)
                {
                    card.BodyControls.AddRange(group.Children);
                }
                else
                {
                    card.BodyControls.Add(body);
                }
            }
            if (footer != null)
            {
                if (footer is WebControlGroup group)
                {
                    card.FooterControls.AddRange(group.Children);
                }
                else
                {
                    card.FooterControls.Add(footer);
                }
            }
            return card;
        }

        // Helper for Card sections to handle multiple controls more easily
        public static WebControlGroup Body(params WebControl[] controls) => new WebControlGroup(controls);
        public static WebControlGroup Header(params WebControl[] controls) => new WebControlGroup(controls);
        public static WebControlGroup Footer(params WebControl[] controls) => new WebControlGroup(controls);

        // Specific HTML elements
        public static Label Label(string text, string htmlFor) => new Label(text, htmlFor);
        public static InputControl TextInput(string id, string bind, string placeholder = null)
            => new InputControl(InputType.Text) { Id = id, BindValueExpression = bind, Placeholder = placeholder };
        public static InputControl DateInput(string id, string bind)
            => new InputControl(InputType.Date) { Id = id, BindValueExpression = bind };
        public static Button Button(string text, Style style, string cssClass = null)
            => new Button(text, style) { CssClass = cssClass };

        // Helper for single column GridRow (for things like address fields)
        public static GridRow SingleColumnRow(params GridColumn[] controls)
            => new GridRow().AddColumn(controls);
    }
}
