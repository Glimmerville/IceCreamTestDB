﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IceCream.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderKey { get; set; }

    }
}