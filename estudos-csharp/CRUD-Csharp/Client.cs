public class Client {

    private string name;
    private string password;
    public Client(string name, string password) {
        this.name = name;
        this.password = password;
    }

    public void setName(string name) {
        this.name = name;
    }

    public void setPassword(string password) {
        this.password = password;
    }


    public string getName() {
        return this.name;
    }

    public string getPassword() {
        return this.password;
    }

}