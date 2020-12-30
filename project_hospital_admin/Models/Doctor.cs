using System.ComponentModel.DataAnnotations;


namespace project_hospital_admin.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public DataType Birthdate { get; set; }
        
        [Required]
        public string Sex { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public string Cnp { get; set; }
        
        [Required]
        public string Specialty { get; set; }
        
        [Required]
        public int Salary { get; set; }
        
    }
}