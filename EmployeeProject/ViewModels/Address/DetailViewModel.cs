namespace EmployeeProject.UI.ViewModels.Address
{
    public class DetailViewModel
    {
        public DetailViewModel()
        {
            Address = new AddressViewModel();
        }

        public AddressViewModel Address { get; set; }
    }
}
