using System.ComponentModel.DataAnnotations;

namespace Efs.Models
{
    public class Inventory
    {
        [Key]
        public int id { get; set; }
        public string? printerBrand { get; set; }
        public string? printerModel { get; set; }
        public string? cartridgeColour { get; set; }
        public string? cartridgeNumber { get; set; }
        public string? cartridgePartNo { get; set; }
        public int? stockQuantity { get; set; }
        public int reorderLevel { get; set; }
    }
}
