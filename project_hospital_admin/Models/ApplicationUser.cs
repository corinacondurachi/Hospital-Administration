using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace project_hospital_admin.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string Sex { get; set; }
        
        public string Birthdate { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public string Cnp { get; set; }
        
    }
}