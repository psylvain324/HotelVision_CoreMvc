using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace HotelVision_CoreMvc.Models
{
    [Serializable]
    [XmlRoot("Inventory")]
    public class InventoryItem
    {
        [Key]
        [MaxLength(10)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [XmlElement("Item Id")]
        public int Id { get; set; }

        [MaxLength(50)]
        [XmlElement("Item Name")]
        public string ItemName { get; set; }

        [XmlElement("Category")]
        public ItemCategory Category { get; set; }

        [MaxLength(5)]
        [XmlElement("Currenct Stock")]
        public int CurrentStock { get; set; }

        [MaxLength(5)]
        [XmlElement("Capacity")]
        public int Capacity { get; set; }

        [MaxLength(5)]
        [JsonIgnore]
        [XmlElement("Remaining Stock")]
        public int RemainingStock { get; set; }

        [JsonIgnore]
        [XmlElement("Stock Percentage")]
        public double StockPercentage { get; set; }

        [DataType(DataType.Currency)]
        public double UnitCost { get; set; }

        public bool Restock { get; set; }

        [DataType(DataType.Date)]
        public string RestockDate { get; set; }

    }

    public enum ItemCategory
    {
        Food = 0,
        Drink = 1,

    }
}
