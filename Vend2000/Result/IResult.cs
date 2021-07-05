namespace Vend2000
{
    public interface IResult
    {
        bool IsSuccessful { get; }
        bool IsFail { get; }
        string Message { get; }
    }

    public interface IResult<T> : IResult
    {
        T Data { get; }
    }
}
