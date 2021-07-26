using System;
using Vend2000.Components;
using Vend2000.Interfaces;

namespace Vend2000
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            ICoinValidator coinValidator = new CoinValidator();
            IDispenser dispenser101 = new SmallDispenser10Slots();
            IDispenser dispenser102 = new SmallDispenser10Slots();
            IDispenser dispenser201 = new SmallDispenser20Slots();
            ICoinStorage coinStorage = new CoinStorage();

            var vend2000 = new Vend2000(coinValidator, coinStorage, dispenser101, dispenser102, dispenser201);
            vend2000.Run();

            Console.CursorVisible = true;
        }
    }
}
