using System.ComponentModel.DataAnnotations;

namespace Mico.ViewModels
{
    public class LoginVM
    {
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
