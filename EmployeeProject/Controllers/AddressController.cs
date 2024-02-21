using EmployeeProject.Core.Interfaces;
using EmployeeProject.Models;
using EmployeeProject.UI.ViewModels;
using EmployeeProject.UI.ViewModels.Address;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProject.UI.Controllers
{
    public class AddressController : Controller
    {
        private readonly IAddress _addressService;

        public AddressController(IAddress addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public IActionResult Create(int employeeId)
        {
            var model = new DetailViewModel
            {
                Address = new AddressViewModel
                {
                    EmployeeId = employeeId
                }
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetailViewModel model)
        {
            if (ModelState.IsValid)
                return await Save(model.Address);

            return View(model);
        }

        [HttpGet]
        public IActionResult Update(long id)
        {
            var address = _addressService.GetById(id);
            if (address == null)
                return NotFound();

            var model = GetDetailViewModel(address);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DetailViewModel model)
        {
            if (ModelState.IsValid)
                return await Save(model.Address);

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var address = _addressService.GetById(id);
            if (address == null)
                return NotFound();

            var model = GetDetailViewModel(address);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DetailViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _addressService.Delete(model.Address.Id);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        #region [ Helper Methods ]
        private DetailViewModel GetDetailViewModel(Address address)
        {
            return new DetailViewModel
            {
                Address = GetAddressViewModel(address)
            };
        }

        private AddressViewModel GetAddressViewModel(Address address)
        {
            if (address == null)
                return null;

            return new AddressViewModel
            {
                Id = address.AddressId,
                EmployeeId = address.EmployeeId,
                Address1 = address.Address1,
                Address2 = address.Address2,
                AddressCity = address.AddressCity,
                AddressState = address.AddressState,
                AddressZip = address.AddressZip
            };
        }

        private Address GetAddressModel(AddressViewModel address)
        {
            return new Address
            {
                AddressId = address.Id,
                EmployeeId = address.EmployeeId,
                Address1 = address.Address1,
                Address2 = address.Address2,
                AddressCity = address.AddressCity,
                AddressState = address.AddressState,
                AddressZip = address.AddressZip
            };
        }

        private async Task<IActionResult> Save(AddressViewModel model)
        {
            var address = GetAddressModel(model);

            address = await _addressService.Save(address);

            return RedirectToAction("Update", new { id = address.AddressId});
        }
        #endregion
    }
}
