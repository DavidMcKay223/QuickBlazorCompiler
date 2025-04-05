using QuickBlazorCompiler.Application.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBlazorCompiler.Application.WebControls.HTML
{
    public class InputControl : WebControl // Inherit from your base class
    {
        public InputType Type { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Placeholder { get; set; }
        public bool IsRequired { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsDisabled { get; set; }
        public Dictionary<string, string> AdditionalAttributes { get; } = new Dictionary<string, string>();
        public string? BindValueExpression { get; set; } // Placeholder for Blazor binding

        public InputControl(InputType type = InputType.Text)
        {
            Type = type;
            CssClass = "form-control"; // Default Bootstrap styling
                                       // Checkboxes and radios typically don't get form-control, adjust if needed
            if (type == InputType.Checkbox || type == InputType.Radio)
            {
                CssClass = "form-check-input";
            }
        }

        public override string GenerateHtml(int indentLevel = 0)
        {
            var indent = GetIndent(indentLevel);
            var sb = new StringBuilder();

            sb.Append($"{indent}<input type=\"{Type.ToHtmlString()}\"");
            sb.Append(GetAttributes()); // Base attributes (Id, CssClass, Style)

            if (!string.IsNullOrWhiteSpace(Name)) sb.Append($" name=\"{Name}\"");
            if (!string.IsNullOrWhiteSpace(Value)) sb.Append($" value=\"{Value}\"");
            if (!string.IsNullOrWhiteSpace(Placeholder)) sb.Append($" placeholder=\"{Placeholder}\"");

            if (IsRequired) sb.Append(" required");
            if (IsReadOnly) sb.Append(" readonly");
            if (IsDisabled) sb.Append(" disabled");

            // Blazor Binding (Simplified - needs more logic for different types)
            if (!string.IsNullOrWhiteSpace(BindValueExpression))
            {
                string bindAttribute = "@bind";
                string bindEvent = "oninput"; // Default for text-like inputs

                switch (Type)
                {
                    case InputType.Checkbox:
                        bindAttribute = "@bind:checked"; // Special case for checkbox bool binding
                        bindEvent = "onchange";
                        // Need to handle 'value' attribute differently if binding checked state
                        break;
                    case InputType.Radio:
                        // Radio binding often works with group name and value
                        bindEvent = "onchange";
                        break;
                    // Potentially add cases for select, etc.
                    default:
                        // bindAttribute = "@bind"; // Default
                        // bindEvent = "oninput"; // Default
                        break;
                }
                sb.Append($" {bindAttribute}=\"{BindValueExpression}\" @bind:event=\"{bindEvent}\"");
            }


            foreach (var attr in AdditionalAttributes)
            {
                sb.Append($" {attr.Key}=\"{attr.Value}\"");
            }

            sb.Append($" />{Environment.NewLine}");

            return sb.ToString();
        }
    }
}
