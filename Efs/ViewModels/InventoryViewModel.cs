using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.ViewModels
{
    public class InventoryViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Printer Name field is required.")]
        [StringLength(100, ErrorMessage = "PrinterName name cannot be greater then 100")]
        public string? PrinterBrand { get; set; }
        [Required(ErrorMessage = "Printer Model field is required.")]
        [StringLength(100, ErrorMessage = "PrinterModel name cannot be greater then 100")]
        public string? PrinterModel { get; set; }
        [Required(ErrorMessage = "Cartridge Colour field is required.")]
        [StringLength(100, ErrorMessage = "CartridgeColour name cannot be greater then 100")]
        public string? CartridgeColour { get; set; }
        [Required(ErrorMessage = "Cartridge Number field is required.")]
        [StringLength(100, ErrorMessage = "CartridgeNumber name cannot be greater then 100")]
        public string? CartridgeNumber { get; set; }
        [Required(ErrorMessage = "Cartridge PartNo field is required.")]
        [StringLength(100, ErrorMessage = "CartridgePartNo name cannot be greater then 100")]
        public string? CartridgePartNo { get; set; }
        [Required(ErrorMessage = "Stock Quantity field is required.")]
        public int? StockQuantity { get; set; }
        public int ReorderLevel { get; set; }
    }
}

