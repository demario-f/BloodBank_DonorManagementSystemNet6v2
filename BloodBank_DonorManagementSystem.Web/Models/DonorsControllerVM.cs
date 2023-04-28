using BloodBank_DonorManagementSystem.Web.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank_DonorManagementSystem.Web.Models
{
    public class DonorsControllerVM 
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Surname Name")]
        [Required]
        public string? LastName { get; set; }

        public string Gender { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public string Address { get; set; }
        public string City { get; set; }


        [ForeignKey("BloodGroupNameId")]
        public BloodType? BloodType { get; set; }
        [Display(Name = "Blood Group")]
        [Required]
        public int BloodGroupNameId { get; set; }

        [Display(Name = "Last Donation Date")]
        public DateTime LastDonationDate { get; set; }
    }
}
