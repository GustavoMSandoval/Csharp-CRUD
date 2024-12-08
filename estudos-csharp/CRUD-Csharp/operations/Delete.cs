using MySql.Data.MySqlClient;

class Delete : Database {

    public async Task DeletePost(int id) {
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

                    var sql = "DELETE FROM posts WHERE id = @id";
                    await using var command = new MySqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", id);

                    var rowsAffected = await command.ExecuteNonQueryAsync();
                    await using var reader = await command.ExecuteReaderAsync();
                    
                    if (rowsAffected > 0) {
                        Console.WriteLine($"Post with id:{id} deleted");
                    } else {
                        Console.WriteLine($"ERROR {id} NOT FOUND");               
                    }
                } else {
                    Console.WriteLine($"ERROR id: {id} NOT FOUND");
                }

            }
        catch (Exception e) {
                Console.WriteLine($"Error: {e.Message}");
            }

            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();

    }

}