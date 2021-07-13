using Vend2000.Components;
using Vend2000.Enums;
using Vend2000.Models;

namespace Vend2000.Interfaces
{
    public interface IDispenser
    {
        int Capacity { get; }
        int Quantity { get; }
        DispenserSize DispenserSize { get; }

        void Add(IProduct product);
        IProduct? Dispense();
    }
}
