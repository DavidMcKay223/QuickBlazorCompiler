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
            var page = new Page("Index.razor")
                .AddControl(new Heading(1, "My Generated Page"))
                .AddControl(new Paragraph("Welcome to this page generated from C#!"))
                .AddControl(new GridRow().CssClass("row g-3")
                    .AddColumn(new GridColumn("col-lg-6 mb-3")
                        .AddChild(new Card().Id("card-one").Title("First Card")
                            .AddBodyControl(new Paragraph("This uses <strong>extension methods</strong>."))
                            .AddBodyControl(new Label("Your Name", "nameInput"))
                            .AddBodyControl(new InputControl(InputType.Text) { Id = "nameInput", Placeholder = "Enter your name", BindValueExpression = "Model.Name" })
                            .AddBodyControl(new GridRow()
                                .AddColumn(FormTemplate.GetGridViewAddressFields("Model.ShippingAddress"))
                            )
                            .AddBodyControl(FormTemplate.GetViewAddressFields("Model.ShippingAddress"))
                            .AddFooterControl(new Button("Submit", Style.Primary))
                            .AddFooterControl(new Button("Cancel", Style.Secondary).CssClass("ms-2"))
                        )
                    )
                    .AddColumn(new GridColumn("col-lg-6 mb-3")
                        .AddChild(new Card().Id("card-two")
                            .AddHeaderControl(new Heading(6, "Another Card").CssClass("text-muted"))
                            .AddBodyControl(new Paragraph("More content here."))
                            .AddBodyControl(new Label("Event Date", "eventDate"))
                            .AddBodyControl(new InputControl(InputType.Date) { Id = "eventDate", BindValueExpression = "Model.EventDate" })
                            .AddBodyControl(new GridRow()
                                .AddColumn(FormTemplate.GetGridEditAddressFields("Model.ShippingAddress"))
                            )
                            .AddBodyControl(FormTemplate.GetEditAddressFields("Model.ShippingAddress"))
                        )
                    )
                )
                .AddControl(new HorizontalRule())
                .AddControl(new Heading(2, "End of Generated Content"));

            page.SaveToFile();

            Console.WriteLine("File Generation Process Complete.");

            // === Keep console open ===
            // Console.ReadKey();
        }
    }
}
