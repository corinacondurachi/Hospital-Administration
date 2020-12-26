using Microsoft.EntityFrameworkCore;
using hospital_administration.Models;


namespace hospital_administration.Data
{
    public class PatientsContext:DbContext
    {
        public PatientsContext (DbContextOptions<PatientsContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Movie { get; set; }
    }
}