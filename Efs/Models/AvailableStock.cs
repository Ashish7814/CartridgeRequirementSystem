using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.Models
{
    public class AvailableStock
    {
        [Key]
        public int? id { get; set; }
        public string? printer_brand { get; set; }
        public string? printer_model { get; set; }
        public string? cartridge_partno { get; set; }
        public string? cartridge_number { get; set; }
        public string? cartridge_colour { get; set; }
        public int? stock_quantity { get; set; }
        public int? issue_quantity { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
