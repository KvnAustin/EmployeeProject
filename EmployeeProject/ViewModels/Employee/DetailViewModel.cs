namespace EmployeeProject.UI.ViewModels.Employee
{
    public class DetailViewModel
    {
        public DetailViewModel()
        {
            Employee = new EmployeeViewModel();
        }

        public EmployeeViewModel Employee { get; set; }
    }
}
