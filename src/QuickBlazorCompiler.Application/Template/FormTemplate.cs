using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Layout;
using System.Collections.Generic;

namespace QuickBlazorCompiler.Application.Template
{
    using static UI;

    public static class FormTemplate
    {
        public static GridColumn[] GetGridViewAddressFields(string modelPrefix)
        {
            return [
                GridColumn("col-12", DisplayLine("Street", $"{modelPrefix}.Street")),

                GridColumn("col-md-4", DisplayLine("City", $"{modelPrefix}.City")),
                GridColumn("col-md-3", DisplayLine("State", $"{modelPrefix}.State")),
                GridColumn("col-md-3", DisplayLine("Zip Code", $"{modelPrefix}.ZipCode")),

                GridColumn("col-md-6", DisplayLine("Phone", $"{modelPrefix}.Phone")),
                GridColumn("col-md-6", DisplayLine("Fax", $"{modelPrefix}.Fax"))
            ];
        }

        public static WebControlGroup GetViewAddressFields(string modelPrefix)
        {
            return Group(
                DisplayLine("Street", $"{modelPrefix}.Street"),
                DisplayLine("City", $"{modelPrefix}.City"),
                DisplayLine("State", $"{modelPrefix}.State"),
                DisplayLine("Zip Code", $"{modelPrefix}.ZipCode"),
                DisplayLine("Phone", $"{modelPrefix}.Phone"),
                DisplayLine("Fax", $"{modelPrefix}.Fax"));
        }

        public static GridColumn[] GetGridEditAddressFields(string modelPrefix, string? idPrefix = null)
        {
            // Use the modelPrefix for IDs if no specific idPrefix is given, replacing dots with underscores
            idPrefix ??= modelPrefix.Replace('.', '_');

            return [
                GridColumn("col-12",
                    Label("Street Address", FieldId(idPrefix, "Street")),
                    InputText("form-control mb-2", FieldId(idPrefix, "Street"), BindExpr(modelPrefix, "Street"), "1234 Main St", true)
                ),

                GridColumn("col-md-4",
                    Label("City", FieldId(idPrefix, "City")),
                    InputText("form-control mb-2", FieldId(idPrefix, "City"), BindExpr(modelPrefix, "City"), null, true)
                ),

                GridColumn("col-md-3",
                    Label("State", FieldId(idPrefix, "State")),
                    InputText("form-control mb-2", FieldId(idPrefix, "State"), BindExpr(modelPrefix, "State"), null, true)
                ),

                GridColumn("col-md-3",
                    Label("Zip Code", FieldId(idPrefix, "ZipCode")),
                    InputText("form-control mb-2", FieldId(idPrefix, "ZipCode"), BindExpr(modelPrefix, "ZipCode"), null, true)
                ),

                GridColumn("col-md-6",
                    Label("Phone", FieldId(idPrefix, "Phone")),
                    InputTel("form-control mb-2", FieldId(idPrefix, "Phone"), BindExpr(modelPrefix, "Phone"), "(555) 555-1234")
                ),

                GridColumn("col-md-6",
                    Label("Fax", FieldId(idPrefix, "Fax")),
                    InputTel("form-control mb-2", FieldId(idPrefix, "Fax"), BindExpr(modelPrefix, "Fax"), "(555) 555-5678")
                )
            ];
        }

        public static WebControlGroup GetEditAddressFields(string modelPrefix, string? idPrefix = null)
        {
            // Use the modelPrefix for IDs if no specific idPrefix is given, replacing dots with underscores
            idPrefix ??= modelPrefix.Replace('.', '_');

            return Group(
                Label("Street Address", FieldId(idPrefix, "Street")),
                InputText("form-control mb-2", FieldId(idPrefix, "Street"), BindExpr(modelPrefix, "Street"), "1234 Main St", true),

                Label("City", FieldId(idPrefix, "City")),
                InputText("form-control mb-2", FieldId(idPrefix, "City"), BindExpr(modelPrefix, "City"), null, true),

                Label("State", FieldId(idPrefix, "State")),
                InputText("form-control mb-2", FieldId(idPrefix, "State"), BindExpr(modelPrefix, "State"), null, true),

                Label("Zip Code", FieldId(idPrefix, "ZipCode")),
                InputText("form-control mb-2", FieldId(idPrefix, "ZipCode"), BindExpr(modelPrefix, "ZipCode"), null, true),

                Label("Phone", FieldId(idPrefix, "Phone")),
                InputTel("form-control mb-2", FieldId(idPrefix, "Phone"), BindExpr(modelPrefix, "Phone"), "(555) 555-1234"),

                Label("Fax", FieldId(idPrefix, "Fax")),
                InputTel("form-control mb-2", FieldId(idPrefix, "Fax"), BindExpr(modelPrefix, "Fax"), "(555) 555-5678"));
        }
    }
}
