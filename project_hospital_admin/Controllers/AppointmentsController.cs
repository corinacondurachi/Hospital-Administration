using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
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
        
        // GET: /Appointments/CreateAppointment
        [HttpGet]
        public ActionResult CreateAppointment()
        {
            return View();
        }
        
        [HttpPost]
        // POST: /Appointments/CreateAppointment
        public ActionResult CreateAppointment (Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);

                _context.SaveChanges();

                return RedirectToAction("ViewAppointments", "Appointments");
            }   

            return View(appointment);
          
        }
        
        // GET: /Appointments/ViewAppointments
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult ViewAppointments()
        {
            ViewData["appointments"] = _context.Appointments.ToList();
            return View();
        }
        
        // GET: /Appointments/EditAppointment/{id}
        [HttpGet]
        public ActionResult EditAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
        
        // POST: /Appointments/EditAppointment
        [HttpPost]
        public ActionResult EditAppointment(Appointment appointment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var oldAppointment = _context.Appointments.Find(appointment.Id);

                    if (oldAppointment == null)
                    {
                        return NotFound();
                    }

                    oldAppointment.CountryCode = appointment.CountryCode;
                    oldAppointment.PhoneNumber = appointment.PhoneNumber;
                    oldAppointment.EmailAddress = appointment.EmailAddress;
                    oldAppointment.Doctor = appointment.Doctor;
                    oldAppointment.AppointmentDate = appointment.AppointmentDate;
                    oldAppointment.Name = appointment.Name;
                    oldAppointment.Sex = appointment.Sex;
                    oldAppointment.Day = appointment.Day;
                    oldAppointment.Month = appointment.Month;
                    oldAppointment.Year = appointment.Year;
                    oldAppointment.Street = appointment.Street;
                    oldAppointment.City = appointment.City;
                    oldAppointment.Country = appointment.Country;
                    oldAppointment.PreviouslyVisited = appointment.PreviouslyVisited;
                    
                    TryUpdateModelAsync(oldAppointment);

                    _context.SaveChanges();

                    return RedirectToAction("ViewAppointments", "Appointments");
                }
            }
            catch (Exception e)
            {
                return Json(new {error_message = e.Message});
            }

            return View(appointment);
        }
        
        // GET: /Appointmnets/DeleteAppointment/{id}
        [HttpGet]
        public ActionResult DeleteAppointment(int id)
        {
            var appointment = _context.Appointments.Find(id);

            if (appointment == null)
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);

            _context.SaveChanges();

            return RedirectToAction("ViewAppointments", "Appointments");
        }

    }
}