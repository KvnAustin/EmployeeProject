using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.UI.ViewModels
{
    public class EmployeeViewModel : BaseEntityViewModel<long>
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        [Required]
        [MaxLength(100)]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }

        public IEnumerable<AddressViewModel> Addresses { get; set; }
    }
}
