using Vend2000.Models;
using Vend2000.Enums;

namespace Vend2000.Components
{
    public class ChipBag : ProductBase
    {
        public ChipBag() : base("Bag of chips", DispenserSize.Large, 99)
        {
        }
    }
}
