using System.ComponentModel.DataAnnotations;

namespace Contract_Monthly_Claim.Models
{
    
    public class AcademicManager
    {
        [Required]
        public string ManagerID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

    }
}