using QuickBlazorCompiler.Application;
using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;
using QuickBlazorCompiler.Application.WebControls.Layout;
using QuickBlazorCompiler.Application.Template;
using QuickBlazorCompiler.Application.Utility;

namespace QuickBlazorCompiler.ConsoleApp
{
    using static UI;
    class Program
    {
        static void Main(string[] args)
        {
            var page = Page("Index.razor",
                Heading(1, "My Generated Page"),
                Paragraph("Welcome to this page generated from C#!"),
                GridRow(columns: [
                    GridColumn("col-lg-6 mb-3",
                        Card("card-one", "First Card",
                            body: Body(
                                Paragraph("This uses <strong>functional composition</strong>."),
                                Label("Your Name", "nameInput"),
                                TextInput("nameInput", "Model.Name", "Enter your name"),
                                SingleColumnRow(FormTemplate.GetGridViewAddressFields("Model.ShippingAddress")),
                                FormTemplate.GetViewAddressFields("Model.ShippingAddress")
                            ),
                            footer: Footer(
                                Button("Submit", Style.Primary),
                                Button("Cancel", Style.Secondary, "ms-2")
                            )
                        )
                    ),
                    GridColumn("col-lg-6 mb-3",
                        Card("card-two",
                            header: Header(Heading(6, "Another Card", "text-muted")),
                            body: Body(
                                Paragraph("More content here."),
                                Label("Event Date", "eventDate"),
                                DateInput("eventDate", "Model.EventDate"),
                                SingleColumnRow(FormTemplate.GetGridEditAddressFields("Model.ShippingAddress")),
                                FormTemplate.GetEditAddressFields("Model.ShippingAddress")
                            )
                        )
                    )
                ]),
                HR(),
                Heading(2, "End of Generated Content")
            );

            page.SaveToFile();

            Console.WriteLine("File Generation Process Complete.");
        }
    }
}
