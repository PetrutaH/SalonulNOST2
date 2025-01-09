using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalonulNOST2.Data;
using SalonulNOST2.Models;

namespace SalonulNOST2.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly SalonulNOST2.Data.SalonulNOST2Context _context;

        public CreateModel(SalonulNOST2.Data.SalonulNOST2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var serviceList = _context.Service
                .Include(s => s.Employee)
                .Select(x => new
                {
                    x.ServiceID,
                    ServiceName = x.Name + " - " + (x.Employee != null ? x.Employee.Name : "No employee")
                }).ToList();

            // Asigură-te că listele de selecție nu sunt null
            ViewData["ServiceID"] = new SelectList(serviceList, "ServiceID", "ServiceName");

            // Populează lista de angajați
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "Name");

            // Populează lista de clienți
            ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "Name");

            return Page();

            //ViewData["ClientID"] = new SelectList(_context.Client, "ClientID", "ClientID");
            //ViewData["EmployeeID"] = new SelectList(_context.Set<Employee>(), "EmployeeID", "EmployeeID");
            //ViewData["ServiceID"] = new SelectList(_context.Set<Service>(), "ServiceID", "ServiceID");
            //    return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointment.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
