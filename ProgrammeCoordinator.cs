using System.ComponentModel.DataAnnotations;

namespace mvc_part1.Models
{
    public class ProgrammeCoordinator
    {
        [Required]
        public string CoordinatorID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        
    }
}
