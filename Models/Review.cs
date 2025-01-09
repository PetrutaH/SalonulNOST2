namespace SalonulNOST2.Models
{
    public class Review
    {

        public int ReviewID { get; set; }
        public string Comment { get; set; } = string.Empty;

        public int Rating { get; set; }
        public int? AppointmentID { get; set; }
        public virtual Appointment? Appointment { get; set; }
    }
}
