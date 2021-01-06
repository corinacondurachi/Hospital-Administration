using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_hospital_admin.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-z]+([\s][a-zA-Z]+)*$", ErrorMessage = "Numele poate sa contina doar litere si spatii")]
        public string Name { get; set; }
        
        [Required]
        public string Sex { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = " Codul tarii poate sa contina doar cifre")]
        public string CountryCode { get; set; }
        
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Numarul de telefon poate sa contina doar cifre")]
        public string PhoneNumber { get; set; }
        
        [Required]
        public string Day { get; set; }
        
        [Required]
        public string Month { get; set; }
        
        [Required]
        public string Year { get; set; }
        
        [Required]
        public string Street { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string State { get; set; }
        
        [Required]
        public string Country { get; set; }
        
        [Required]
        public string EmailAddress { get; set; }
        
        [Required]
        public string PreviouslyVisited { get; set; }
        
        public string VisitMotive { get; set; }
        
        [Required]
        public string AppointmentDate { get; set; }
        
        [Required]
        public string Doctor { get; set; }
        
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public ApplicationUser ApplicationUser { get; set; }
        
        
        
    }
}