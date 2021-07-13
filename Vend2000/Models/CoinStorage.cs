using System.Collections.Generic;
using System.Linq;

namespace Vend2000
{
    public class CoinStorage : ICoinStorage
    {
        private readonly List<ICoin> coins = new List<ICoin>(100);

        public int Capacity => 100;
        public int CoinCount => coins.Count();

        public List<ICoin> Empty()
        {
            var coinsToEmpty = new List<ICoin>(CoinCount);

            coinsToEmpty.AddRange(coins);

            coins.Clear();
            return coinsToEmpty;
        }

        public void Add(ICoin coin)
        {
            if (CoinCount >= Capacity)
            {
                return;
            }

            coins.Add(coin);
        }
    }
}
