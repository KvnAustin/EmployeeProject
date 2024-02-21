using EmployeeProject.Core.Interfaces;
using EmployeeProject.Models;
using EmployeeProject.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Core.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return QueryEmployees()
                .ToList();
        }

        public Employee GetById(long employeeId)
        {
            return QueryEmployees()
                .FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public async Task<Employee> Save(Employee employee)
        {
            _context.Update(employee);

            await _context.SaveChangesAsync();

            return employee;
        }

        public async Task Delete(long employeeId)
        {
            var employee = GetById(employeeId);

            _context.Remove(employee);

            await _context.SaveChangesAsync();
        }

        #region [ Helper Methods ]
        private IQueryable<Employee> QueryEmployees()
        {
            return _context.Employees
                .Include(x => x.Address)
                .OrderByDescending(x => x.HireDate);
        }
        #endregion
    }
}
