﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Position : EntityStatus
    { 
        public int PositionId { get; set; }

        public string? PositionName { get; set; }
    }
}
