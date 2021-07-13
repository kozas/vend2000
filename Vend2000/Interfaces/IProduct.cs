using Vend2000.Enums;

namespace Vend2000.Interfaces
{
    public interface IProduct
    {
        public string Name { get; }
        public DispenserSize DispenserSize { get; }
    }
}
