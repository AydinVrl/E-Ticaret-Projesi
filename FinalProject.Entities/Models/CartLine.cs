﻿using FinalProject.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities.Models
{
    public class CartLine
    {
        //?
        public int CartLineId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
