namespace QuickBlazorCompiler.ConsoleApp
{
    using QuickBlazorCompiler.Application;
    using QuickBlazorCompiler.Application.WebControls;
    
    class Program
    {
        static void Main(string[] args)
        {
            var page = new Page("index.razor");
            var grid = new Grid();
            var card1 = new Card();
            var card2 = new Card();
            
            grid.Children.Add(card1);
            grid.Children.Add(card2);
            page.Add(grid);

            page.SaveToFile();

            Console.WriteLine("File Generated.");
        }
    }
}
