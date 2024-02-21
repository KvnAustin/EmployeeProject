using EmployeeProject.Core.Interfaces;
using EmployeeProject.Models;
using EmployeeProject.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeProject.Core.Services
{
    public class AddressService : IAddress
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Address> GetAll()
        {
            return QueryAddresses()
                .ToList();
        }

        public Address GetById(long addressId)
        {
            return QueryAddresses()
                .FirstOrDefault(x => x.AddressId == addressId);
        }

        public async Task<Address> Save(Address address)
        {
            _context.Update(address);

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task Delete(long addressId)
        {
            var address = GetById(addressId);

            _context.Remove(address);

            await _context.SaveChangesAsync();
        }

        #region [ Helper Methods ]
        private IQueryable<Address> QueryAddresses()
        {
            return _context.Address
                .Include(x => x.Employee);
        }
        #endregion
    }
}
