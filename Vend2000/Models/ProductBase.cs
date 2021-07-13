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

        protected ProductBase(string name, DispenserSize dispenserSize)
        {
            Name = name;
            DispenserSize = dispenserSize;
        }
    }
}
