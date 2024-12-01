using System.Security.Cryptography;

namespace LetMeCookAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        private string PasswordSalt = "LetThemCook";
        public DateTime Age { get; set; }

        public User() { }

        public User(int id, string name, string email, string username, string passwordHash, DateTime age)
        {
            Id = id;
            Name = name;
            Email = email;
            Username = username;
            MD5 md5Hash = MD5.Create();
            byte[] passwordBytes = md5Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordHash + PasswordSalt));
            PasswordHash = Convert.ToBase64String(passwordBytes);
            Age = age;
        }

    }
}
