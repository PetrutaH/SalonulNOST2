using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonulNOST2.Data;
using SalonulNOST2.Models;

namespace SalonulNOST2.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly SalonulNOST2.Data.SalonulNOST2Context _context;

        public IndexModel(SalonulNOST2.Data.SalonulNOST2Context context)
        {
            _context = context;
        }

        public IList<Appointment> Appointment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Appointment != null)
            {
                Appointment = await _context.Appointment
                .Include(b => b.Service)
                .ThenInclude(b => b.Employee)
                .Include(b => b.Client).ToListAsync();
            }

            //Appointment = await _context.Appointment
            //    .Include(a => a.Client)
            //    .Include(a => a.Employee)
            //    .Include(a => a.Service).ToListAsync();
        }
    }
}
