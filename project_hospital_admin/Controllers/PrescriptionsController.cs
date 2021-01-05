using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using project_hospital_admin.Data;
using project_hospital_admin.Models;

namespace project_hospital_admin.Controllers
{
    public class PrescriptionsController : Controller
    {
        private ApplicationDbContext _context;

        public PrescriptionsController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        // GET: /Prescriptions/CreatePrescription
        [HttpGet]
        public ActionResult CreatePrescription()
        {
            return View();
        }

        [HttpPost]
        // POST: /Prescriptions/CreatePrescription
        public ActionResult CreatePrescription(Prescription prescription)
        {

            var user = _context.ApplicationUsers.FirstOrDefault(x => x.Email == prescription.EmailAddress);
            if (user != null)
            {
                prescription.UserId = user.Id;
            }

            if (ModelState.IsValid)
            {
                _context.Prescriptions.Add(prescription);

                _context.SaveChanges();
                
                var user2 = _context.ApplicationUsers.FirstOrDefault(x => x.Id == User.FindFirstValue(ClaimTypes.NameIdentifier));
                if (user2.Role == "Admin")
                {
                    return RedirectToAction("ViewPrescriptions", "Prescriptions");
                }
                if (user2.Role == "Doctor")
                {
                    return RedirectToAction("ViewPrescriptionsDoctor", "Prescriptions");
                }
                
            }

            return View(prescription);

        }

        // GET: /Prescriptions/ViewPrescriptions
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ViewPrescriptions()
        {
            ViewData["prescriptions"] = _context.Prescriptions.ToList();
            return View();
        }
        
        // GET: /Prescriptions/ViewPrescriptionsPatient
        [HttpGet]
        public ActionResult ViewPrescriptionsPatient()
        {
            ViewData["prescriptions"] = _context.Prescriptions
                .Where(x => x.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToList();

            return View();
        }
        
        // GET: /Prescriptions/ViewPrescriptionsDoctor
        [HttpGet]
        public ActionResult ViewPrescriptionsDoctor()
        {
            ViewData["prescriptions"] = _context.Prescriptions.ToList();
            return View();
        }



    }
}


