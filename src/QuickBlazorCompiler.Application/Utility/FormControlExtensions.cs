using QuickBlazorCompiler.Application.WebControls.HTML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBlazorCompiler.Application.Utility
{
    public static class FormControlExtensions
    {
        public static InputControl Required(this InputControl control)
        {
            control.IsRequired = true;
            return control;
        }

        //public static InputControl WithValidation(this InputControl control, string message)
        //{
        //    control.ValidationMessage = message;
        //    return control;
        //}

        //public static InputControl WithPattern(this InputControl control, string regexPattern)
        //{
        //    control.Pattern = regexPattern;
        //    return control;
        //}

        //public static Label For(this Label label, string inputId)
        //{
        //    label.HtmlFor = inputId;
        //    return label;
        //}
    }
}
