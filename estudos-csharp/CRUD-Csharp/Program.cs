namespace project {    
    class Program
    {
        static  async Task Main(string[] args) 
        {
            
            string? option = "";

            while(option != "5") {

                    Console.WriteLine("""
                    ------Choose an option------
                        1-Create
                        2-Read
                        3-Update
                        4-Delete
                        5-Exit
                    """);

                option = Console.ReadLine();

                switch (option) {
                    case "1":
                        await Actions.Create();
                    break;
                    case "2":
                        await Actions.Read();
                    break;
                    case "3":
                        await Actions.Update();
                    break;
                    case "4":
                        await Actions.Delete();
                    break;
                    case "5":
                        Console.WriteLine("Ending Program...");
                    break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Option try again.");
                        Console.ResetColor();
                    break;
                    
                }

            }
           
        }
    }
}
