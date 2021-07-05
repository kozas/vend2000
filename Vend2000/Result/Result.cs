namespace Vend2000
{
    public static class Result
    {
        public static IResult Success(string message = "Success")
        {
            return new ResultWithoutData(true, message);
        }

        public static IResult<T> Success<T>(T data, string message = "Success")
        {
            return new ResultWithData<T>(true, message, data);
        }

        public static IResult Fail(string message = "Fail")
        {
            return new ResultWithoutData(false, message);
        }

        public static IResult<T> Fail<T>(T data, string message = "Fail")
        {
            return new ResultWithData<T>(false, message, data);
        } 
        
        public static IResult<T> Fail<T>(string message = "Fail")
        {
            return new ResultWithData<T>(false, message, default(T));
        }
    }
}
