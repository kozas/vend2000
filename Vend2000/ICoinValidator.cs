namespace Vend2000
{
    public interface ICoinValidator
    {
        CoinType DetermineCoinType(ICoin coin);
    }
}
