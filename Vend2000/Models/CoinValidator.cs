using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vend2000
{
    public class CoinValidator : ICoinValidator
    {
        public CoinType DetermineCoinType(ICoin coin)
        {
            if (coin.Weight == 11 && coin.Diameter == 30)
            {
                return CoinType.Gold;
            }

            if (coin.Weight == 5 && coin.Diameter == 24)
            {
                return CoinType.Silver;
            }

            if (coin.Weight == 2 && coin.Diameter == 17)
            {
                return CoinType.Bronze;
            }

            return CoinType.Unknown;
        }
    }
}
