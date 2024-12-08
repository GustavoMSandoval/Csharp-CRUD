class Database
{

    protected string connection;
    public  Database(string server = "localhost", string port = "3306", string database = "mydb", string user = "root", string password = "")
    {
        this.connection = "Server=localhost;Port=3306;Database=mydb;User ID=root;Password='';";
    }
}
