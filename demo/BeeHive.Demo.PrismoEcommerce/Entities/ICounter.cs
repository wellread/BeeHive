﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeeHive.Demo.PrismoEcommerce.Entities
{
    public interface ICounter
    {
        Guid Id { get; }

        long Value { get; }
    }
}