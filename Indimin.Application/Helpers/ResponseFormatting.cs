namespace Indimin.Application.Helpers;

public class ResponseFormatting<T>
{
    public T? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; }
    public List<string>? Errors { get; set; }
    public int StatusCode { get; set; }

    public ResponseFormatting()
    {
        
    }

    public ResponseFormatting(T? data, string? message, int statusCode = 200, bool success = true)
    {
        Data = data;
        Message = message;
        StatusCode = statusCode;
        Success = success;
    }
    
    public ResponseFormatting(string? message, int statusCode, bool success)
    {
        Message = message;
        StatusCode = statusCode;
        Success = success;
    }
}
