using MySql.Data.MySqlClient;

class Update : Database {
    
    public async Task UpdatePost(int? id, string? title, string? text) {
        
        
        try {
                await using var connection = new MySqlConnection(this.connection);
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();

                var verify = "SELECT COUNT(*) FROM posts WHERE id = @id";
                await using var verified = new MySqlCommand(verify, connection);
                verified.Parameters.AddWithValue("@id",id);

                var check = Convert.ToInt32(await verified.ExecuteScalarAsync());


                if (check > 0) {

                    var sql = "UPDATE posts SET title = @title, text = @text WHERE id = @id";
                    await using var command = new MySqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@text", text);

                    var rowsAffected = await command.ExecuteNonQueryAsync();
                    await using var reader = await command.ExecuteReaderAsync();
                    
                    if (rowsAffected > 0) {
                        Console.WriteLine($"ID: {id}, Title: {title}, Text: {text} updated!!!");
                    } else {
                        Console.WriteLine($"ERROR {id} NOT FOUND");               
                    }
                }

            }
        catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();

        
    }

}