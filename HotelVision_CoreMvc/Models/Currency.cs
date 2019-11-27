using System.ComponentModel.DataAnnotations;

namespace HotelVision_CoreMvc.Models
{
    public class Currency
    {
        [Key]
        public int CurrencyId { get; set; }
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
    }
}
