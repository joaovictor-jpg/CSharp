using Products.API.Config;
using Products.API.Models.Enums;

namespace Products.API.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public void SetPasswordHash()
        {
            Password = Password.GenerateHast();
        }
    }
}
