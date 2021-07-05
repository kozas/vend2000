namespace Vend2000
{
    public class GoldCoin : ICoin
    {
        public string Name => "Gold";
        public CoinType CoinType => CoinType.Gold;
    }
}
