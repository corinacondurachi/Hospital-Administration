using Microsoft.AspNetCore.Mvc;
using project_hospital_admin.Data;
using project_hospital_admin.Models;

namespace project_hospital_admin.Controllers
{
    /*public class PatientsController: Controller
    {
        private PatientDbContext _context;

        public PatientsController(PatientDbContext patientDbContext)
        {
            _context = patientDbContext;
        }

        
        [HttpPost]
        // Get /patient/new
        public ActionResult New(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Add(patient);

                _context.SaveChanges();

                return RedirectToAction("Index", "HomeController");
                
            }   

            return View(patient);
          
        }

    }*/
}