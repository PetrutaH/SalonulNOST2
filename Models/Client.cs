namespace SalonulNOST2.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
