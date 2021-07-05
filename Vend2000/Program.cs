using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Vend2000
{
    class Program
    {
        static void Main(string[] args)
        {
            ICoinValidator coinValidator = null;
            IGumDispenser gumDispenser = null;
            ICoinStorage coinStorage = null;

            //coinValidator = new CoinValidator();
            //gumDispenser = new GumDispenser();
            //coinStorage = new CoinStorage();

            var vend2000 = new Vend2000(coinValidator, gumDispenser, coinStorage);
            vend2000.Run();
        }
    }
}
