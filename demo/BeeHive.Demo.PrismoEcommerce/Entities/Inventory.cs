﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive.Demo.PrismoEcommerce.Entities
{
    public class Inventory
    {
        public Guid ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
