
namespace Vend2000
{
    public interface IGumDispenser
    {
        int Capacity { get; }
        int Quantity { get; }
        IResult Load(GumPacket gumPacket);
        IResult<GumPacket> Dispense();
    }
}
