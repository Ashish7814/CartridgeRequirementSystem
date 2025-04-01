using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.Models
{
    public class RequestCartridge
    {
        [Key]
        public int? id { get; set; }
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
        public string? required_quantity { get; set; }
        [Required]
        public string? user_name { get; set; }
        [Required]
        public string? department { get; set; }
        [Required]
        public string? status { get; set; }
        public DateTime createdAt { get; set; }
    }
}
