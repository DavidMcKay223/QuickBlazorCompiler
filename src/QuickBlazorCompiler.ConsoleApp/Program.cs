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
            var page = Page("Index.razor")
                .AddComponents(
                    Heading(1, "My Generated Page"),
                    Paragraph("Welcome to this page generated from C#!"),
                    GridRow()
                        .WithColumns(
                            GridColumn("col-lg-6 mb-3",
                                Card("card-one", "First Card",
                                    body: Body(
                                        Paragraph("This uses <strong>functional composition</strong>.")
                                    )
                                ).WithFooter(
                                    Button("Submit", Style.Primary),
                                    Button("Cancel", Style.Secondary, "ms-2")
                                )
                            ),
                            GridColumn("col-lg-6 mb-3",
                                Card("card-two")
                                    .WithHeader(Heading(6, "Another Card", "text-muted"))
                                    .WithBody(
                                        Paragraph("More content here."),
                                        SingleColumnRow(FormTemplate.GetGridEditAddressFields("Model.ShippingAddress"))
                                    )
                            )
                        ));

            page.SaveToFile();

            Console.WriteLine("File Generation Process Complete.");
        }
    }
}
