using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.UI.ViewModels
{
    public class AddressViewModel : BaseEntityViewModel<long>
    {
        public long EmployeeId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [MaxLength(100)]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "City")]
        public string AddressCity { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "State")]
        public string AddressState { get; set; }

        [Required]
        [MaxLength(5)]
        [Display(Name = "ZIP Code")]
        public string AddressZip { get; set; }
    }
}
