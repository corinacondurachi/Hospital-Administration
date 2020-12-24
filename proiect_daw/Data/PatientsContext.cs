using Microsoft.EntityFrameworkCore;
using DbContext = System.Data.Entity.DbContext;

namespace proiect_daw.Data
{
    public class PatientsContext: DbContext
    {
        public PatientsContext(DbContextOptions <PatientsContext> options): base(options){}
        public System.Data.Entity.DbSet<Models.Patient> Patients { get; set; }
    }
}
