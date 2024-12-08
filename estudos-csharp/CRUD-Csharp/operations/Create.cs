using MySql.Data.MySqlClient;
class Create : Database {

    public async Task CreateUser(string? username, string? email) {
         
        try {
                await using var connection = new MySqlConnection(this.connection);

                await connection.OpenAsync();

                var sql = "INSERT INTO users (user_id, name, email) VALUES (null, @name, @email)";
                await using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", username);
                command.Parameters.AddWithValue("@email", email);

                int success = await command.ExecuteNonQueryAsync();
                
                string response = $"""
                Values 
                Username: {username}, E-mail: {email}
                inserted!
                """;

                if (success != 1) {
                    response = "Error with the creation of an user !";
                }
                
                Console.WriteLine(response);
                
            }
        catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
    }
    public async Task CreatePost(string? title, string? text, string userID) {
        
           try {
                await using var connection = new MySqlConnection(this.connection);

                await connection.OpenAsync();

                var sql = "INSERT INTO posts (id, title, text, user_id) VALUES (null, @title, @text, @user_id)";
                await using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@title", title);
                command.Parameters.AddWithValue("@text", text);
                command.Parameters.AddWithValue("@user_id", userID);

                int success = await command.ExecuteNonQueryAsync();
                
                string response = $"Values\n Title: {title}, Text: {text}, User ID: {userID} \ninserted!";

                if (success != 1) {
                    response = "Error with the creation of a post !";
                }
                
                Console.WriteLine(response);
                
            }
        catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();

    }
}