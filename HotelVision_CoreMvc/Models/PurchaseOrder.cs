using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelVision_CoreMvc.Models
{
    public class PurchaseOrder
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
