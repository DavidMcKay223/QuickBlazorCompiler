using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using System.Collections.Generic;

namespace QuickBlazorCompiler.Application.Template
{
    public static class FormTemplate
    {
        public static List<GridColumn> GetGridViewAddressFields(string modelPrefix)
        {
            var fields = new List<GridColumn>();

            // Helper function to create a display line
            static Paragraph CreateDisplayLine(string label, string valueExpression) =>
                new Paragraph($"<strong>{label}:</strong> @({valueExpression})"); // Use Razor syntax placeholder

            fields.Add(new GridColumn { Children = { CreateDisplayLine("Street", $"{modelPrefix}.Street") }, CssClass = "col-12" });

            fields.Add(new GridColumn { Children = { CreateDisplayLine("City", $"{modelPrefix}.City") }, CssClass = "col-md-4" });
            fields.Add(new GridColumn { Children = { CreateDisplayLine("State", $"{modelPrefix}.State") }, CssClass = "col-md-3" });
            fields.Add(new GridColumn { Children = { CreateDisplayLine("Zip Code", $"{modelPrefix}.ZipCode") }, CssClass = "col-md-3" });

            fields.Add(new GridColumn { Children = { CreateDisplayLine("Phone", $"{modelPrefix}.Phone") }, CssClass = "col-md-6" });
            fields.Add(new GridColumn { Children = { CreateDisplayLine("Fax", $"{modelPrefix}.Fax") }, CssClass = "col-md-6" });

            return fields;
        }

        public static WebControlGroup GetViewAddressFields(string modelPrefix)
        {
            var fields = new List<WebControl>();

            // Helper function to create a display line
            static Paragraph CreateDisplayLine(string label, string valueExpression) =>
                new Paragraph($"<strong>{label}:</strong> @({valueExpression})"); // Use Razor syntax placeholder

            fields.Add(CreateDisplayLine("Street", $"{modelPrefix}.Street"));
            fields.Add(CreateDisplayLine("City", $"{modelPrefix}.City"));
            fields.Add(CreateDisplayLine("State", $"{modelPrefix}.State"));
            fields.Add(CreateDisplayLine("Zip Code", $"{modelPrefix}.ZipCode"));
            fields.Add(CreateDisplayLine("Phone", $"{modelPrefix}.Phone"));
            fields.Add(CreateDisplayLine("Fax", $"{modelPrefix}.Fax"));

            return new WebControlGroup(fields);
        }

        public static List<GridColumn> GetGridEditAddressFields(string modelPrefix, string? idPrefix = null)
        {
            // Use the modelPrefix for IDs if no specific idPrefix is given, replacing dots with underscores
            idPrefix ??= modelPrefix.Replace('.', '_');

            var fields = new List<GridColumn>();

            // Helper to generate unique IDs
            static string FieldId(string prefix, string fieldName) => $"{prefix}_{fieldName}";
            // Helper to generate binding expressions
            static string BindExpr(string prefix, string fieldName) => $"{prefix}.{fieldName}";

            // --- Street Address ---
            fields.Add(new GridColumn
            {
                CssClass = "col-12 mb-2",
                Children = {
                new Label("Street Address", FieldId(idPrefix, "Street")),
                new InputControl(InputType.Text)
                {
                    Id = FieldId(idPrefix, "Street"),
                    Placeholder = "1234 Main St",
                    BindValueExpression = BindExpr(modelPrefix, "Street"),
                    IsRequired = true,
                    CssClass = "form-control"
                }
            }
            });

            // --- Street Address 2 (Optional) ---
            fields.Add(new GridColumn
            {
                CssClass = "col-12 mb-2",
                Children = {
                new Label("Street Address 2 (Optional)", FieldId(idPrefix, "Street2")),
                new InputControl(InputType.Text)
                {
                    Id = FieldId(idPrefix, "Street2"),
                    Placeholder = "Apartment, studio, or floor",
                    BindValueExpression = BindExpr(modelPrefix, "Street2"),
                    CssClass = "form-control"
                }
            }
            });

            // --- City ---
            fields.Add(new GridColumn
            {
                CssClass = "col-md-4 mb-2",
                Children = {
                new Label("City", FieldId(idPrefix, "City")),
                new InputControl(InputType.Text)
                {
                    Id = FieldId(idPrefix, "City"),
                    BindValueExpression = BindExpr(modelPrefix, "City"),
                    IsRequired = true,
                    CssClass = "form-control"
                }
            }
            });

            // --- State ---
            fields.Add(new GridColumn
            {
                CssClass = "col-md-3 mb-2",
                Children = {
                new Label("State", FieldId(idPrefix, "State")),
                new InputControl(InputType.Text)
                { // TODO: Replace with SelectControl later
                    Id = FieldId(idPrefix, "State"),
                    BindValueExpression = BindExpr(modelPrefix, "State"),
                    IsRequired = true,
                    CssClass = "form-control"
                }
            }
            });

            // --- Zip Code ---
            fields.Add(new GridColumn
            {
                CssClass = "col-md-3 mb-2",
                Children = {
                new Label("Zip Code", FieldId(idPrefix, "ZipCode")),
                new InputControl(InputType.Text)
                {
                    Id = FieldId(idPrefix, "ZipCode"),
                    BindValueExpression = BindExpr(modelPrefix, "ZipCode"),
                    IsRequired = true,
                    CssClass = "form-control"
                }
            }
            });

            // --- Phone ---
            fields.Add(new GridColumn
            {
                CssClass = "col-md-6 mb-2",
                Children = {
                new Label("Phone", FieldId(idPrefix, "Phone")),
                new InputControl(InputType.Tel)
                {
                    Id = FieldId(idPrefix, "Phone"),
                    Placeholder = "(555) 555-1234",
                    BindValueExpression = BindExpr(modelPrefix, "Phone"),
                    CssClass = "form-control"
                }
            }
            });

            // --- Fax (Optional) ---
            fields.Add(new GridColumn
            {
                CssClass = "col-md-6 mb-2",
                Children = {
                new Label("Fax (Optional)", FieldId(idPrefix, "Fax")),
                new InputControl(InputType.Tel)
                {
                    Id = FieldId(idPrefix, "Fax"),
                    Placeholder = "(555) 555-5678",
                    BindValueExpression = BindExpr(modelPrefix, "Fax"),
                    CssClass = "form-control"
                }
            }
            });

            return fields;
        }

        public static WebControlGroup GetEditAddressFields(string modelPrefix, string? idPrefix = null)
        {
            // Use the modelPrefix for IDs if no specific idPrefix is given, replacing dots with underscores
            idPrefix ??= modelPrefix.Replace('.', '_');

            var fields = new List<WebControl>();

            // Helper to generate unique IDs
            static string FieldId(string prefix, string fieldName) => $"{prefix}_{fieldName}";
            // Helper to generate binding expressions
            static string BindExpr(string prefix, string fieldName) => $"{prefix}.{fieldName}";

            // --- Street Address ---
            fields.Add(new Label("Street Address", FieldId(idPrefix, "Street")));
            fields.Add(new InputControl(InputType.Text)
            {
                Id = FieldId(idPrefix, "Street"),
                Placeholder = "1234 Main St",
                BindValueExpression = BindExpr(modelPrefix, "Street"),
                IsRequired = true,
                CssClass = "form-control mb-2" // Add margin-bottom to separate fields vertically if needed
            });

            // --- Street Address 2 (Optional) ---
            fields.Add(new Label("Street Address 2 (Optional)", FieldId(idPrefix, "Street2")));
            fields.Add(new InputControl(InputType.Text)
            {
                Id = FieldId(idPrefix, "Street2"),
                Placeholder = "Apartment, studio, or floor",
                BindValueExpression = BindExpr(modelPrefix, "Street2"),
                CssClass = "form-control mb-2"
            });

            // --- City ---
            fields.Add(new Label("City", FieldId(idPrefix, "City")));
            fields.Add(new InputControl(InputType.Text)
            {
                Id = FieldId(idPrefix, "City"),
                BindValueExpression = BindExpr(modelPrefix, "City"),
                IsRequired = true,
                CssClass = "form-control mb-2"
            });

            // --- State ---
            fields.Add(new Label("State", FieldId(idPrefix, "State")));
            fields.Add(new InputControl(InputType.Text)
            { // TODO: Replace with SelectControl later
                Id = FieldId(idPrefix, "State"),
                BindValueExpression = BindExpr(modelPrefix, "State"),
                IsRequired = true,
                CssClass = "form-control mb-2" // This might need adjustment when placed in columns
            });

            // --- Zip Code ---
            fields.Add(new Label("Zip Code", FieldId(idPrefix, "ZipCode")));
            fields.Add(new InputControl(InputType.Text)
            {
                Id = FieldId(idPrefix, "ZipCode"),
                BindValueExpression = BindExpr(modelPrefix, "ZipCode"),
                IsRequired = true,
                CssClass = "form-control mb-2" // This might need adjustment when placed in columns
            });

            // --- Phone ---
            fields.Add(new Label("Phone", FieldId(idPrefix, "Phone")));
            fields.Add(new InputControl(InputType.Tel)
            {
                Id = FieldId(idPrefix, "Phone"),
                Placeholder = "(555) 555-1234",
                BindValueExpression = BindExpr(modelPrefix, "Phone"),
                CssClass = "form-control mb-2"
            });

            // --- Fax (Optional) ---
            fields.Add(new Label("Fax (Optional)", FieldId(idPrefix, "Fax")));
            fields.Add(new InputControl(InputType.Tel)
            {
                Id = FieldId(idPrefix, "Fax"),
                Placeholder = "(555) 555-5678",
                BindValueExpression = BindExpr(modelPrefix, "Fax"),
                CssClass = "form-control mb-2"
            });

            return new WebControlGroup(fields);
        }
    }
}
