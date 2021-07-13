using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend2000
{
    public abstract class GumDispenserBase : IGumDispenser
    {
        private readonly Stack<GumPacket> gumPackets = new Stack<GumPacket>();

        public int Capacity { get; }
        public int Quantity => gumPackets.Count();

        protected GumDispenserBase(int capacity)
        {
            Capacity = capacity;
        }

        public void Add(GumPacket gumPacket)
        {
            if (Quantity >= Capacity)
            {
                return;
            }

            gumPackets.Push(gumPacket);
        }

        public GumPacket? Dispense()
        {
            if (Quantity == 0)
            {
                return null;
            }

            var packetToDispense = gumPackets.Pop();
            return packetToDispense;
        }
    }
}
