namespace Vend2000
{
    public class ResultWithData<T> : IResult<T>
    {
        public bool IsSuccessful { get; }
        public bool IsFail => !IsSuccessful;
        public string Message { get; }
        public T Data { get; }

        public ResultWithData(bool isSuccessful, string message, T data)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            Data = data;
        }
    }
}