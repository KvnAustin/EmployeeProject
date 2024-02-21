using EmployeeProject.Models;

namespace EmployeeProject.Core.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAll();

        Employee GetById(long employeeId);

        Task<Employee> Save(Employee employee);

        Task Delete(long employeeId);
    }
}
