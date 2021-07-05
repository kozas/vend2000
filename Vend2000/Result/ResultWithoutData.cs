namespace Vend2000
{
    public class ResultWithoutData : IResult
    {
        public bool IsSuccessful { get; }
        public bool IsFail => !IsSuccessful;
        public string Message { get; }
        
        public ResultWithoutData(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }
    }
}