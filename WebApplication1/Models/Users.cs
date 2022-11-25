using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Users
    {
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Fill login")]
        [Display(Name = "User login")]
        public string Login { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")]
        [Required]
        [StringLength(30)]
        public string Password { get; set;}

        public string Role { get; set; }

    }
}
