using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank_DonorManagementSystem.Web.Data
{
    public class Donation : BaseEntity
    {
        [ForeignKey("DonorId")]
        public Donor Donor { get; set; }
        public int DonorId { get; set; }

        public DateTime DonationDate { get; set; }

        [ForeignKey("BloodTypeId")]
        public BloodType BloodType { get; set; }
        public int BloodTypeId { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
