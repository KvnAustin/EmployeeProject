namespace EmployeeProject.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string JobTitle { get; set; }

        public DateTime HireDate { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
