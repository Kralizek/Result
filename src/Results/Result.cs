namespace Kralizek.Results;

public static class Result
{
    public static Result<T> Success<T>(T value) => new SuccessResult<T>(value);

    public static Result<T> Fail<T>(string message) => new FailedResult<T>(message);

    public static Result<T> NotFound<T>(string? message = null) => new NotFoundResult<T>(message);

    public static Result<T> NotAuthorized<T>(string? message = null) => new NotAuthorizedResult<T>(message);

    public static Result<T> Conflict<T>(string message) => new ConflictResult<T>(message);
}

public abstract class Result<T>
{
    public bool IsSuccess { get; protected init;}
    
    public bool IsError { get; protected init; }

    public static implicit operator Result<T>(T value) => Result.Success(value);
}
