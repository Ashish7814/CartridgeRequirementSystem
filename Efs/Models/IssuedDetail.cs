using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.Models
{
    public class IssuedDetail
    {
        [Key]
        public int? id { get; set; }
        [Required]
        public string? user_name { get; set; }
        [Required]
        public string? department { get; set; }
        [Required]
        public string? cartridge_colour { get; set; }
        [Required]
        public string? cartridge_number { get; set; }
        [Required]
        public string? cartridge_partno { get; set; }
        [Required]
        public int? issued_quantity { get; set; }
        public DateTime date { get; set; }
    }
}
