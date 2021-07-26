using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vend2000.Enums;
using Vend2000.Interfaces;

namespace Vend2000.Models
{
    public abstract class ProductBase : IProduct
    {
        public string Name { get; }
        public DispenserSize DispenserSize { get; }
        public int Cost { get; }

        protected ProductBase(string name, DispenserSize dispenserSize, int cost)
        {
            Name = name;
            DispenserSize = dispenserSize;
            Cost = cost;
        }
    }
}
