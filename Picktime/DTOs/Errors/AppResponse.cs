using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Picktime.DTOs.Errors
{
    public class AppResponse
    {
        public bool IsSuccess => Errors.Count == 0;
        public List<Error> Errors { get; set; } = new List<Error>();
        public DateTime ResponseTime { get; set; } = DateTime.Now;
        public ResponseStatus ResponseStatus { get; set; } = ResponseStatus.Ok;

        public AppResponse()
        {

        }

        public AppResponse(ResponseStatus responseStatus)
        {
            ResponseStatus = responseStatus;
        }

        public AppResponse(List<Error> errors)
        {
            Errors = errors;
        }

        public static AppResponse Success()
        {
            return new AppResponse(ResponseStatus.Ok);
        }

        public static AppResponse Success(string message)
        {
            return new AppResponse(ResponseStatus.Ok);
        }

        public static AppResponse Error(params Error[] Errors)
        {
            return new AppResponse(ResponseStatus.Error) { Errors = Errors.ToList() };
        }

    }

    public class AppResponse<T> : AppResponse
    {
        public T Data { get; set; }

        public AppResponse()
        {

        }

        public AppResponse(T data)
        {
            Data = data;
        }

        public AppResponse(List<Error> errors) : base(errors)
        {

        }

        public AppResponse(ResponseStatus status)
        {

        }

        public static AppResponse<T> Success(T Data)
        {
            return new AppResponse<T>(Data);
        }

        public static new AppResponse<T> Error(params Error[] Errors)
        {
            return new AppResponse<T>(ResponseStatus.Error) { Errors = Errors.ToList() };
        }

    }

    public enum ResponseStatus
    {
        Ok = 200,
        Error = 500,
    }
}
