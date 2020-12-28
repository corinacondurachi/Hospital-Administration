using System.ComponentModel.DataAnnotations;


namespace project_hospital_admin.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [EmailAddress]
        //[Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        //[Display(Name = "Password")]
        public string Password { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public DataType Birthdate { get; set; }
        
        public string Sex { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public string Cnp { get; set; }
    }
}