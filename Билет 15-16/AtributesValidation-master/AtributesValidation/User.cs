using System.ComponentModel.DataAnnotations;

namespace AtributesValidation
{
    public class User : IValidatable
    {
        [MinLength(2)]
        [Required(AllowEmptyStrings = false)]
        public string Login { get; set; }

        [MinLength(5)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
