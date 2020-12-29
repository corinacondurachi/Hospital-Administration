using Microsoft.AspNetCore.Mvc;
using project_hospital_admin.Data;
using project_hospital_admin.Models;

namespace project_hospital_admin.Controllers
{
    public class AppointmentsController: Controller
    {
        private ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        
        // GET: /appointment/create
        [HttpGet]
        public ActionResult CreateAppointment()
        {
            return View();
        }
        
        [HttpPost]
        // POST: /appointment/create
        public ActionResult CreateAppointment (Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);

                _context.SaveChanges();

                return RedirectToAction("CreateAppointment", "Appointments");
            }   

            return View(appointment);
          
        }

    }
}