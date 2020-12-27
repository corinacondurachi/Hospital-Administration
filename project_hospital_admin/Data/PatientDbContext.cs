using Microsoft.EntityFrameworkCore;
using project_hospital_admin.Models;

namespace project_hospital_admin.Data
{
    public class PatientDbContext:DbContext
    {
        public PatientDbContext (DbContextOptions<PatientDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
    }
    
}