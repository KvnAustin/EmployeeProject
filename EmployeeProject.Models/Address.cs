namespace EmployeeProject.Models
{
    public class Address
    {
        public long AddressId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string AddressCity { get; set; }

        public string AddressState { get; set; }

        public string AddressZip { get; set; }

        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
