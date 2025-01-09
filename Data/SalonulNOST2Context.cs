using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using SalonulNOST2.Models;

namespace SalonulNOST2.Data
{
    public class SalonulNOST2Context : DbContext
    {
        public SalonulNOST2Context (DbContextOptions<SalonulNOST2Context> options)
            : base(options)
        {
        }

        public DbSet<SalonulNOST2.Models.Client> Client { get; set; } = default!;
        public DbSet<SalonulNOST2.Models.Appointment> Appointment { get; set; } = default!;
        public DbSet<SalonulNOST2.Models.Employee> Employee { get; set; } = default!;
        public DbSet<SalonulNOST2.Models.Review> Review { get; set; } = default!;
        public DbSet<SalonulNOST2.Models.Service> Service { get; set; } = default!;
    }
}
