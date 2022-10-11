using System.ComponentModel.DataAnnotations;

namespace CustomerCRUD.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
