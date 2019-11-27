using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelVision_CoreMvc.Models
{
    public class Review
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Review")]
        public int ReviewId { get; set; }

        [Required(ErrorMessage = "Description of Service is required.")]
        [DataType(DataType.MultilineText)]
        public string serviceDescription;

        [Required(ErrorMessage = "Description of Food Quality is required.")]
        [DataType(DataType.MultilineText)]
        public string foodDescription;

        [Required(ErrorMessage = "Service rating is required.")]
        public int serviceRating;

        [Required(ErrorMessage = "Food rating is required.")]
        public int foodRating;

        [Required(ErrorMessage = "Overall rating is required.")]
        public int overallRating;

        public virtual Employee employee { get; set; }
    }
}
