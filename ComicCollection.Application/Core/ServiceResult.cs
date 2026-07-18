namespace ComicCollection.Application.Core;

public class ServiceResult<T>
{
    public bool Success { get; set; }

    public string Message { get; set; } = string.Empty;

    public T? Data { get; set; }

    public static ServiceResult<T> Ok(T data)
    {
        return new ServiceResult<T>
        {
            Success = true,
            Data = data,
            Message = "Operation completed successfully."
        };
    }

    public static ServiceResult<T> Fail(string message)
    {
        return new ServiceResult<T>
        {
            Success = false,
            Message = message
        };
    }
}