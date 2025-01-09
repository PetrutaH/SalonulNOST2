using System.ComponentModel.DataAnnotations;

namespace SalonulNOST2.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int? ServiceID { get; set; }
        public Service? Service { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        public int? EmployeeID { get; set; }
        public Employee? Employee { get; set; }
        public DateTime AppointmentDate { get; set; }
    }
}
