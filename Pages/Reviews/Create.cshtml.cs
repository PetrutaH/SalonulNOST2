using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SalonulNOST2.Data;
using SalonulNOST2.Models;

namespace SalonulNOST2.Pages.Reviews
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
        ViewData["AppointmentID"] = new SelectList(_context.Appointment, "AppointmentID", "AppointmentID");
            return Page();
        }

        [BindProperty]
        public Review Review { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Review.Add(Review);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
