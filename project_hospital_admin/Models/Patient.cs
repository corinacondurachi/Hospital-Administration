using System.ComponentModel.DataAnnotations;


namespace project_hospital_admin.Models
{
    public class Patient
    {
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