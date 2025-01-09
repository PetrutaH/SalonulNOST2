namespace SalonulNOST2.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public ICollection<Service>? Services { get; set; }
    }
}
