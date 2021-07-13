using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vend2000.Models;

namespace Vend2000.Components
{
    public class SmallDispenser20Slots : DispenserBase
    {
        public SmallDispenser20Slots() : base(20, Enums.DispenserSize.Small)
        {
        }
    }
}
