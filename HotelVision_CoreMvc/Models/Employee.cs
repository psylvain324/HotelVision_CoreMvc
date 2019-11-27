using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelVision_CoreMvc.Models.ViewModels;

namespace HotelVision_CoreMvc.Models
{
    public class Employee
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [DataType(DataType.Text)]
        public string City { get; set; }

        [Required(ErrorMessage ="State is required.")]
        [DataType(DataType.Text)]
        public string State { get; set; }

        [Required(ErrorMessage = "Country is required.")]
        [DataType(DataType.Text)]
        public Country Country { get; set; }

        [DataType(DataType.PostalCode)]
        [Required(ErrorMessage = "Postal Code is required.")]
        public string Zip { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
    }
}
