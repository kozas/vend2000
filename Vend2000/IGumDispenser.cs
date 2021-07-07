
namespace Vend2000
{
    public interface IGumDispenser
    {
        int Capacity { get; }
        int Quantity { get; }
        void Add(GumPacket gumPacket);
        GumPacket? Dispense();
    }
}
