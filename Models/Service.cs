using System.ComponentModel.DataAnnotations.Schema;

namespace SalonulNOST2.Models
{
    public class Service
    {

        public int ServiceID { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
        public int? EmployeeID { get; set; }
        public Employee? Employee { get; set; }
    }
}
