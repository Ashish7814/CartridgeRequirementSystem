using Efs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.ViewModels
{
    public class BrandCartridgesViewModel
    {
        public string Brand { get; set; }
        public IEnumerable<CartridgeDetail> Cartridges { get; set; }
    }
}
