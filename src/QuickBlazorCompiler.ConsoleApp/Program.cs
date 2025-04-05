using QuickBlazorCompiler.Application;
using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;
using QuickBlazorCompiler.Application.WebControls.Layout;
using QuickBlazorCompiler.Application.Template;
using QuickBlazorCompiler.Application.Utility;

namespace QuickBlazorCompiler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var page = UI.Page("Index.razor",
                UI.Heading(1, "My Generated Page"),
                UI.Paragraph("Welcome to this page generated from C#!"),
                UI.GridRow(columns: new[] {
                    UI.GridColumn("col-lg-6 mb-3",
                        UI.Card("card-one", "First Card",
                            body: UI.Body(
                                UI.Paragraph("This uses <strong>functional composition</strong>."),
                                UI.Label("Your Name", "nameInput"),
                                UI.TextInput("nameInput", "Model.Name", "Enter your name"),
                                UI.SingleColumnRow(FormTemplate.GetGridViewAddressFields("Model.ShippingAddress")),
                                FormTemplate.GetViewAddressFields("Model.ShippingAddress")
                            ),
                            footer: UI.Body(
                                UI.Button("Submit", Style.Primary),
                                UI.Button("Cancel", Style.Secondary, "ms-2")
                            )
                        )
                    ),
                    UI.GridColumn("col-lg-6 mb-3",
                        UI.Card("card-two",
                            header: UI.Header(UI.Heading(6, "Another Card", "text-muted")),
                            body: UI.Body(
                                UI.Paragraph("More content here."),
                                UI.Label("Event Date", "eventDate"),
                                UI.DateInput("eventDate", "Model.EventDate"),
                                UI.SingleColumnRow(FormTemplate.GetGridEditAddressFields("Model.ShippingAddress")),
                                FormTemplate.GetEditAddressFields("Model.ShippingAddress")
                            )
                        )
                    )
                }),
                UI.HR(),
                UI.Heading(2, "End of Generated Content")
            );

            page.SaveToFile();

            Console.WriteLine("File Generation Process Complete.");
        }
    }
}
