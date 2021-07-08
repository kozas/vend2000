using System;

namespace Vend2000
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            ICoinValidator coinValidator = new CoinValidator();
            IGumDispenser gumDispenser10 = new GumDispenser10();
            IGumDispenser gumDispenser20 = new GumDispenser20();
            ICoinStorage coinStorage = new CoinStorage();

            var vend2000 = new Vend2000(coinValidator, gumDispenser10, coinStorage);
            vend2000.Run();

            Console.CursorVisible = true;
        }
    }
}
