using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using HotelVision_CoreMvc.Models.Enums;

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
        [XmlElement("Current Stock")]
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
        [XmlElement("Unit Cost")]
        public double UnitCost { get; set; }

        [DataType(DataType.Currency)]
        [JsonIgnore]
        [XmlElement("Total Cost")]
        public double TotalCost { get; set; }

        [XmlElement("Restock Scheduled")]
        public bool RestockScheduled { get; set; }

        [DataType(DataType.Date)]
        [XmlElement("Restock Schedule Date")]
        public string RestockScheduleDate { get; set; }

        [DataType(DataType.Date)]
        [XmlElement("Last Restock")]
        public string LastRestock { get; set; }

        [DataType(DataType.DateTime)]
        [XmlElement("Last Modified Date")]
        public string LastModifiedDate { get; set; }
    }
}
