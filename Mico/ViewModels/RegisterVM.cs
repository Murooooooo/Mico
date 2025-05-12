using System.ComponentModel.DataAnnotations;

namespace Mico.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }


    }
}
