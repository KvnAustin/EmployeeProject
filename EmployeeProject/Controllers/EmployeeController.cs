using EmployeeProject.Core.Interfaces;
using EmployeeProject.Models;
using EmployeeProject.UI.ViewModels;
using EmployeeProject.UI.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAll();

            var model = GetIndexViewModel(employees);

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new DetailViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetailViewModel model)
        {
            if (ModelState.IsValid)
                return await Save(model.Employee);

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();

            var model = GetDetailViewModel(employee);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DetailViewModel model)
        {
            if (ModelState.IsValid)
                return await Save(model.Employee);

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
                return NotFound();

            var model = GetDetailViewModel(employee);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.Delete(model.Employee.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        #region [ Helper Methods ]
        private IndexViewModel GetIndexViewModel(IEnumerable<Employee> employees)
        {
            return new IndexViewModel
            {
                Employees = GetEmployeesViewModel(employees)
            };
        }
        
        private DetailViewModel GetDetailViewModel(Employee employee)
        {
            return new DetailViewModel
            {
                Employee = GetEmployeeViewModel(employee)
            };
        }

        private IEnumerable<EmployeeViewModel> GetEmployeesViewModel(IEnumerable<Employee> employees)
        {
            return employees
                .Select(employee => GetEmployeeViewModel(employee))
                .ToList();
        }

        private EmployeeViewModel GetEmployeeViewModel(Employee employee)
        {
            return new EmployeeViewModel
            {
                Id = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JobTitle = employee.JobTitle,
                HireDate = employee.HireDate,
                Addresses = GetAddressesViewModel(employee.Address)
            };
        }

        private Employee GetEmployeeModel(EmployeeViewModel employee)
        {
            return new Employee
            {
                EmployeeId = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                JobTitle = employee.JobTitle,
                HireDate = employee.HireDate.Value
            };
        }

        private IEnumerable<AddressViewModel> GetAddressesViewModel(IEnumerable<Address> addresses)
        {
            return addresses
                .Select(address => GetAddressViewModel(address))
                .ToList();
        }

        private AddressViewModel GetAddressViewModel(Address address)
        {
            if (address == null)
                return null;

            return new AddressViewModel
            {
                Id = address.AddressId,
                Address1 = address.Address1,
                Address2 = address.Address2,
                AddressCity = address.AddressCity,
                AddressState = address.AddressState,
                AddressZip = address.AddressZip
            };
        }

        private async Task<IActionResult> Save(EmployeeViewModel model)
        {
            var employee = GetEmployeeModel(model);

            employee = await _employeeService.Save(employee);

            return RedirectToAction("Update", new { id = employee.EmployeeId });
        }
        #endregion
    }
}