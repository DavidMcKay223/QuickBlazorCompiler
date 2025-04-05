using QuickBlazorCompiler.Application;
using QuickBlazorCompiler.Application.WebControls;
using QuickBlazorCompiler.Application.WebControls.HTML;
using QuickBlazorCompiler.Application.WebControls.Bootstrap;
using QuickBlazorCompiler.Application.WebControls.Layout;

namespace QuickBlazorCompiler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // --- Create the Page using object initializers ---
            var page = new Page("Index.razor")
            {
                Controls =
                {
                    new Heading(1, "My Generated Page"),
                    new Paragraph("Welcome to this page generated from C#!"),
                    new GridRow // Main layout grid
                    {
                        CssClass = "row g-3", // Add gutters
                        Columns =
                        {
                            new GridColumn("col-lg-6 mb-3") // First column
                            {
                                Children =
                                {
                                    new Card
                                    {
                                        Id = "card-one",
                                        Title = "First Card",
                                        BodyControls =
                                        {
                                            new Paragraph("This uses <strong>object initializers</strong>."),
                                            new Label("Your Name", "nameInput"),
                                            new InputControl(InputType.Text) {
                                                Id = "nameInput",
                                                Placeholder = "Enter your name",
                                                BindValueExpression = "Model.Name" // Binding example
                                            }
                                        },
                                        FooterControls =
                                        {
                                            new Button("Submit", Style.Primary),
                                            new Button("Cancel", Style.Secondary) { CssClass = "ms-2" }
                                        }
                                    }
                                }
                            },
                            new GridColumn("col-lg-6 mb-3") // Second column
                            {
                                Children =
                                {
                                     new Card
                                    {
                                        Id = "card-two",
                                         HeaderControls = { new Heading(6, "Another Card") { CssClass="text-muted"} },
                                        BodyControls =
                                        {
                                            new Paragraph("More content here."),
                                            new Label("Event Date", "eventDate"),
                                            new InputControl(InputType.Date){ Id = "eventDate", BindValueExpression="Model.EventDate"}
                                        }
                                    }
                                }
                            }
                        }
                    },
                    new HorizontalRule(),
                    new Heading(2, "End of Generated Content")
                }
            };

            // --- Save the Page to a file ---
            page.SaveToFile(); // Saves to GeneratedOutput/Index.razor

            Console.WriteLine("File Generation Process Complete.");

            // === Keep console open ===
            // Console.ReadKey();
        }
    }
}
