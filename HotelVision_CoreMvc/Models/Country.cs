using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace HotelVision_CoreMvc.Models.ViewModels
{
    public class Country
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CountryCode { get; set; }

        public string CountryName { get; set; }

        public string CountryLanguage { get; set; }

        [ForeignKey("CurrencyId")]
        [JsonIgnore]
        public int? CustomerId { get; set; }

        public Currency Currency { get; set; }
    }
}
