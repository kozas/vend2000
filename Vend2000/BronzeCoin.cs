namespace Vend2000
{
    public class BronzeCoin : ICoin
    {
        public string Name => "Bronze";
        public CoinType CoinType => CoinType.Bronze;
    }
}