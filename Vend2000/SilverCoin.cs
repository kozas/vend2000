namespace Vend2000
{
    public class SilverCoin : ICoin
    {
        public string Name => "Silver";
        public CoinType CoinType => CoinType.Silver;
    }
}
