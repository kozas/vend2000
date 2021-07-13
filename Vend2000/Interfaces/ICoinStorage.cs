using System.Collections.Generic;

namespace Vend2000
{
    public interface ICoinStorage
    {
        List<ICoin> Empty();
        void Add(ICoin coin);
        int CoinCount { get; }
        int Capacity { get; }
    }
}
