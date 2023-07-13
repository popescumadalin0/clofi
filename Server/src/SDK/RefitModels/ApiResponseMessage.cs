using System.Net;

namespace SDK.RefitModels;

public class ApiResponseMessage
{
    public ApiResponseMessage(bool success, HttpStatusCode statusCode = HttpStatusCode.OK, string responseMessage = null)
    {
        this.Success = success;
        this.ResponseMessage = responseMessage;
        this.StatusCode = (int)statusCode;
    }

    public ApiResponseMessage(bool success, int statusCode, string responseMessage = null)
    {
        this.Success = success;
        this.ResponseMessage = responseMessage;
        this.StatusCode = statusCode;
    }

    public bool Success { get; set; }

    public string ResponseMessage { get; set; }

    public int StatusCode { get; set; }
}

public class ApiResponseMessage<T>
{
    public ApiResponseMessage(
        bool success,
        T response,
        HttpStatusCode statusCode = HttpStatusCode.OK,
        string responseMessage = null)
    {
        this.Success = success;
        this.ResponseMessage = responseMessage;
        this.StatusCode = (int)statusCode;
        this.Response = response;
    }

    public ApiResponseMessage(bool success, T response, int statusCode, string responseMessage = null)
    {
        this.Success = success;
        this.ResponseMessage = responseMessage;
        this.StatusCode = statusCode;
        this.Response = response;
    }

    public bool Success { get; set; }

    public string ResponseMessage { get; set; }

    public int StatusCode { get; set; }

    public T Response { get; set; }
}