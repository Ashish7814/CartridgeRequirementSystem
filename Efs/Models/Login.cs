﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efs.Models
{
    public class Login
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? password { get; set; }
    }
}
