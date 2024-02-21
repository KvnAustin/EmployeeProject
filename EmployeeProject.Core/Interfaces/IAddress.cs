using EmployeeProject.Models;

namespace EmployeeProject.Core.Interfaces
{
    public interface IAddress
    {
        IEnumerable<Address> GetAll();

        Address GetById(long addressId);

        Task<Address> Save(Address address);

        Task Delete(long addressId);
    }
}
