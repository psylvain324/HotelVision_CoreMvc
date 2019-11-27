using System.ComponentModel.DataAnnotations;

namespace HotelVision_CoreMvc.Models.ViewModels
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
    }
}
