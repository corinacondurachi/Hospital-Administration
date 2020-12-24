using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace proiect_daw.Data
{
    public class PatientsContext: IdentityDbContext
    {
        public PatientsContext(DbContextOptions <PatientsContext> options): base(options){}
        public System.Data.Entity.DbSet<Models.Patient> Patients { get; set; }
    }
}
