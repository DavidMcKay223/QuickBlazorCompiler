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
            var page = new Page("Index.razor").AddControls(
                new Heading(1, "My Generated Page"),
                new Paragraph("Welcome to this page generated from C#!"),
                new GridRow().WithCssClass("row g-3").AddColumns(
                    new GridColumn("col-lg-6 mb-3").AddChildren(
                        new Card().WithId("card-one").Title("First Card")
                            .AddBodyControls(
                                new Paragraph("This uses <strong>extension methods</strong>."),
                                new Label("Your Name", "nameInput"),
                                new InputControl(InputType.Text).WithId("nameInput").WithPlaceholder("Enter your name").WithBind("Model.Name"),
                                new GridRow().AddColumn(FormTemplate.GetGridViewAddressFields("Model.ShippingAddress")),
                                FormTemplate.GetViewAddressFields("Model.ShippingAddress")
                            )
                            .AddFooterControls(
                                new Button("Submit", Style.Primary),
                                new Button("Cancel", Style.Secondary).WithCssClass("ms-2")
                            )
                    ),
                    new GridColumn("col-lg-6 mb-3").AddChildren(
                        new Card().WithId("card-two")
                            .AddHeaderControls(new Heading(6, "Another Card").WithCssClass("text-muted"))
                            .AddBodyControls(
                                new Paragraph("More content here."),
                                new Label("Event Date", "eventDate"),
                                new InputControl(InputType.Date)
                                    .WithId("eventDate")
                                    .WithBind("Model.EventDate"),
                                new GridRow().AddColumn(FormTemplate.GetGridEditAddressFields("Model.ShippingAddress")),
                                FormTemplate.GetEditAddressFields("Model.ShippingAddress")
                            )
                    )
                ),
                new HorizontalRule(),
                new Heading(2, "End of Generated Content")
            );

            page.SaveToFile();

            Console.WriteLine("File Generation Process Complete.");

            // === Keep console open ===
            // Console.ReadKey();
        }
    }
}
