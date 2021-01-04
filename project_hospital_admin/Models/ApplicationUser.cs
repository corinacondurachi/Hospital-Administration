using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


namespace project_hospital_admin.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = "Prenumele poate sa contina doar litere si spatii")]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = "Numele poate sa contina doar litere si spatii")]
        public string LastName { get; set; }
        
        [Required]
        public string Sex { get; set; }
        
        public string Birthdate { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numarul de telefon poate sa contina doar cifre")]
        public string PhoneNumber { get; set; }
        
        [RegularExpression(@"^[1256][0-9]{12}$", ErrorMessage = "CNP invalid")]
        public string Cnp { get; set; }

        public string Role { get; set; } = "Pacient";

        // public ICollection<Appointment> Appointments { get; set; }

    }
}