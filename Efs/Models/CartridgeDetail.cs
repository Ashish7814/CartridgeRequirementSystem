using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.Models
{
    public class CartridgeDetail
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? printer_brand { get; set; }
        [Required]
        public string? printer_model { get; set; }
        [Required]
        public string? cartridge_colour { get; set; }
        [Required]
        public string? cartridge_number { get; set; }
        [Required]
        public string? cartridge_partNo { get; set; }
        [Required]
        public int? stock_quantity { get; set; }
        public DateTime createdAt { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime updatedAt { get; set; }
    }
}
