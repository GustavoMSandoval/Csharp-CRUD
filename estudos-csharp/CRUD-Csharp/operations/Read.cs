using MySql.Data.MySqlClient;

class Read : Database {
     

    public async Task ReadAllPosts() {
        
        try {
                await using var connection = new MySqlConnection(this.connection);
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();

                var sql = "SELECT * FROM posts";
                await using var command = new MySqlCommand(sql, connection);
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    // Extract each column based on its index and type
                    var id = reader.GetInt32(0);          // First column: id (int)
                    var title = reader.GetString(1);     // Second column: title (varchar)
                    var text = reader.GetString(2);      // Third column: text (text)
                    var userId = reader.GetInt32(3);     // Fourth column: user_id (int)

                    Console.WriteLine($"ID: {id}, Title: {title}, Text: {text}, UserID: {userId}");
                }
            }
        catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
    }

    public async Task ReadOnePost(int id) {

        try {
                await using var connection = new MySqlConnection(this.connection);
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();

                var sql = "SELECT * FROM posts WHERE id = @id";
                await using var command = new MySqlCommand(sql, connection);
                

                command.Parameters.AddWithValue("@id", id);          
                
                await using var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {

                                  
                    var title = reader.GetString(1);     
                    var text = reader.GetString(2);      
                    var userId = reader.GetInt32(3);     

                    Console.WriteLine($" Title: {title}, Text: {text}, User ID: {userId}");
                }
            }
        catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
    }
}