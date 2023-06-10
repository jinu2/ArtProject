namespace ArtProject.Models
{
    public class UserModel
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public string Username { get; set; }
    public string Password { get; set; }

    public UserModel(string name, int age, string email, string username, string password)
    {
        Name = name;
        Age = age;
        Email = email;
        Username = username;
        Password = password;
    }

    public UserModel()
    {
    }
}
}