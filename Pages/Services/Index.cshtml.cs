using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SalonulNOST2.Data;
using SalonulNOST2.Models;

namespace SalonulNOST2.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly SalonulNOST2.Data.SalonulNOST2Context _context;

        public IndexModel(SalonulNOST2.Data.SalonulNOST2Context context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; } = default!;

        public string NameSort { get; set; }

        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            CurrentSort = sortOrder;
            // Setare direcție sortare

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            // Construire interogare cu sortare
            IQueryable<Service> servicesQuery = _context.Service;

            if (sortOrder == "name_desc")
            {
                servicesQuery = servicesQuery.OrderByDescending(s => s.Name);
            }
            else
            {
                servicesQuery = servicesQuery.OrderBy(s => s.Name);
            }
            // Aplicați filtrarea (căutare)
            if (!String.IsNullOrEmpty(searchString))
            {
                servicesQuery = servicesQuery.Where(s => s.Name.Contains(searchString));
            }


            // Execută interogarea
            Service = await servicesQuery.AsNoTracking().ToListAsync();


            //Service = await _context.Service
            //    .Include(s => s.Employee).ToListAsync();
        }
    }
}
