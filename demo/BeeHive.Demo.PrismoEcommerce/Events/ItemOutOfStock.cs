﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive.Demo.PrismoEcommerce.Events
{
    public class ItemOutOfStock
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}