public class Actions {

    public static async Task Create() {

        Create Create = new();

        string? option = "";

        while (option != "1" || option != "2") { 

            Console.WriteLine("""
            ------Create------
            1-An user
            2-A post
            """);
            option = Console.ReadLine();

            List<string?> verify = new();

            verify.Add(option);
        

            if(option == "1") {

            Console.WriteLine("What's the name of the user ?");

            string? username = Console.ReadLine();

            Console.WriteLine("His E-mail:");

            string? email = Console.ReadLine();

            
            await Create.CreateUser(username, email);

            break;

            } else if (option == "2") {
                
                Console.WriteLine("What's the title of the post ?");

                string? title = Console.ReadLine();

                Console.WriteLine("Write the post text:");

                string? text = Console.ReadLine();
                
                break;

            } 
        }

    }

    public static async Task Read() {

        string? option = "";

        while (option != "Y" || option != "N") {  
                    Console.WriteLine("Do you want to see all posts? [Y/N]");
                    option  = Console.ReadLine();

                    if(option?.ToUpper() == "Y") {

                    Read Read = new();

                    await Read.ReadAllPosts();

                    break;

                } else if (option?.ToUpper() == "N") {

                    Console.WriteLine("Which post do you want to see ?");
                    string? postId = Console.ReadLine();

                    Read Read = new();
                    await Read.ReadOnePost(Convert.ToInt32(postId));

                    break;

                }  else {
                    Console.WriteLine("Choose between Y and N");
                }
        }

    }

    public static async Task Update() {
        Console.WriteLine("Select the post you want to update");
        string? id = Console.ReadLine();
        Console.WriteLine("Change the title");
        string? title = Console.ReadLine();
        Console.WriteLine("Change the text");
        string? text = Console.ReadLine();


        Update Update = new();
        await Update.UpdatePost(Convert.ToInt16(id),title,text);

    }

    public static async Task Delete() {
        Console.WriteLine("Select the post you want to delete");
        string? id = Console.ReadLine();

        Delete Delete = new();
        await Delete.DeletePost(Convert.ToInt16(id));
    }

}