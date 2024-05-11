namespace Kralizek.Results;

public class FailedResult<T> : Result<T>
{
    public FailedResult(string message)
    {
        Message = message;
        IsSuccess = false;
        IsError = true;
    }

    public string Message { get; }
}

public sealed class NotFoundResult<T>(string? message = null) : FailedResult<T>(message ?? "Item not found");

public sealed class NotAuthorizedResult<T>(string? message = null) : FailedResult<T>(message ?? "Access not authorized");

public sealed class ConflictResult<T>(string message) : FailedResult<T>(message);