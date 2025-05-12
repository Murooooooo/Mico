using System.ComponentModel.DataAnnotations;

namespace Mico.Models
{
    public class Doctor
    {
        public  int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        //[Required]
        public string? PhotoUrl { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(15)]
        public string Duty { get; set; }
    }
}
