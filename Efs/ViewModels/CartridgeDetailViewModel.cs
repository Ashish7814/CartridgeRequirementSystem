using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.ViewModels
{
    public class CartridgeDetailViewModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Printer Brand field is required.")]
        [StringLength(100, ErrorMessage = "Printer Brand name cannot be greater then 100")]
        public string? printer_brand { get; set; }
        [Required(ErrorMessage = "Printer Model field is required.")]
        [StringLength(100, ErrorMessage = "Model Name cannot be greater then 100")]
        public string? printer_model { get; set; }
        [Required(ErrorMessage = "Cartridge Colour field is required.")]
        [StringLength(100, ErrorMessage = "Cartridge Colour cannot be greater then 100")]
        public string? cartridge_colour { get; set; }
        [Required(ErrorMessage = "Cartridge Number field is required.")]
        [StringLength(100, ErrorMessage = "Cartridge Number cannot be greater then 100")]
        public string? cartridge_number { get; set; }
        [Required(ErrorMessage = "Cartridge part Number field is required.")]
        [StringLength(100, ErrorMessage = "Cartridge Part Number cannot be greater then 100")]
        public string? cartridge_partNo { get; set; }
        [Required(ErrorMessage = "Stock Quantity field is required.")]
        public int? stock_quantity { get; set; }
        public DateTime createdAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime updatedAt { get; set; }
    }
}
