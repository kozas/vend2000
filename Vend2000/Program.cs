using System;

namespace Vend2000
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            ICoinValidator coinValidator = new CoinValidator();
            IGumDispenser gumDispenser = new GumDispenser10Unit();
            ICoinStorage coinStorage = new CoinStorage();

            var vend2000 = new Vend2000(coinValidator, gumDispenser, coinStorage);
            vend2000.Run();

            Console.CursorVisible = true;
        }
    }
}
