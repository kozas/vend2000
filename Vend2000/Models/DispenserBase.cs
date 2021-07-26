using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vend2000.Components;
using Vend2000.Enums;
using Vend2000.Interfaces;

namespace Vend2000.Models
{
    public abstract class DispenserBase : IDispenser
    {
        private readonly Stack<IProduct> loadedProducts = new Stack<IProduct>();

        public int Quantity => loadedProducts.Count();
        public int Capacity { get; }
        public DispenserSize DispenserSize { get; }

        protected DispenserBase(int capacity, DispenserSize dispenserSize)
        {
            Capacity = capacity;
            DispenserSize = dispenserSize;
        }

        public void Add(IProduct product)
        {
            if (product.DispenserSize != DispenserSize)
            {
                return;
            }

            if (Quantity >= Capacity)
            {
                return;
            }

            loadedProducts.Push(product);
        }

        public IProduct? Dispense()
        {
            if (Quantity == 0)
            {
                return null;
            }

            var productToDispense = loadedProducts.Pop();

            return productToDispense;
        }
    }
}
