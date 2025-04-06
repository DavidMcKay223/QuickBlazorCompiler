using QuickBlazorCompiler.Application.Utility.ENUM;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using QuickBlazorCompiler.Application.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class CardExtensions
    {
        public static Card WithHeader(this Card card, params WebControl[] content)
        {
            card.HeaderControls.AddRange(content);
            return card;
        }

        public static Card WithBody(this Card card, params WebControl[] content)
        {
            card.BodyControls.AddRange(content);
            return card;
        }

        public static Card WithFooter(this Card card, params WebControl[] content)
        {
            card.FooterControls.AddRange(content);
            return card;
        }

        public static Card WithTitle(this Card card, string title, HeadingLevel level = HeadingLevel.H5)
        {
            card.HeaderControls.Add(new Heading((int)level, title));
            return card;
        }

        public static Card AsCollapsible(this Card card)
        {
            card.CssClass += " collapsible";
            return card;
        }

        public static Card WithTitle(this Card card, string title)
        {
            card.Title = title;
            return card;
        }

        public static Card WithId(this Card card, string id)
        {
            card.Id = id;
            return card;
        }

        public static Card WithCssClass(this Card card, string cssClass)
        {
            card.CssClass = cssClass;
            return card;
        }
    }
}
