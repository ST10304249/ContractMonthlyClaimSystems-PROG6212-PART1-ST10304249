using System.ComponentModel.DataAnnotations;

namespace Contract_Monthly_Claim.Models
{
    public class Lecturer
    {
        [Required]
        public string LecturerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

       
    }
}