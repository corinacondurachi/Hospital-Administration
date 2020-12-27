using System.ComponentModel.DataAnnotations;


namespace project_hospital_admin.Models
{
    public class Patient
    {
        [Key]
        public int Id { get; set; }
        
        [EmailAddress]
        // [OnlyGmail(ErrorMessage = "Adresa de email este invalida!")]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        public DataType Birthdate { get; set; }
        
        [Required]
        public string PhoneNumber { get; set; }
        
        public string Cnp { get; set; }
    }
}