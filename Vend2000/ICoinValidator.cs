namespace Vend2000
{
    public interface ICoinValidator
    {
        IResult<bool> Validate(ICoin coin, CoinType coinType);
    }
}
