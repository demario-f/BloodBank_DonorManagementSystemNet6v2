using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank_DonorManagementSystem.Web.Data
{
    public class Donor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public string City { get; set; }


        [ForeignKey("BloodGroupNameId")]
        public BloodType BloodType { get; set; }
        public int BloodGroupNameId { get; set; }

        public DateTime LastDonationDate { get; set; }

    }
}
