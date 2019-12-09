﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaiteRaju.Entities
{
   public class PriceEntity
    {
        public decimal FinalPrice { get; set; }
        public decimal FinalCost { get; set; }
        public decimal FinalFuelCost { get; set; }
        public decimal FinalDriverCost { get; set; }
        public decimal AvgTollCost { get; set; }
    }
}
