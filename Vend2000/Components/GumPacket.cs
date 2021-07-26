using Vend2000.Models;
using Vend2000.Enums;

namespace Vend2000.Components
{
    public class GumPacket : ProductBase
    {
        public GumPacket() : base("Gum Packet", DispenserSize.Small, 65)
        {
        }
    }
}
