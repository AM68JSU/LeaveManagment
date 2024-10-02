using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagment.Mvc.Models.Identity
{
    public class LoginVM
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
    }
}
