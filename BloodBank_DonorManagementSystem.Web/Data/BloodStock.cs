using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank_DonorManagementSystem.Web.Data
{
    public class BloodStock : BaseEntity
    {
        [ForeignKey("BloodTypeId")]
        public BloodType BloodType { get; set; }
        public int BloodTypeId { get; set; }

        public int Quantity { get; set; }
    }
}
 