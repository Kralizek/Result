namespace Kralizek.Results;

public readonly record struct Unit
{
    public static readonly Unit Value = new Unit();

    public override string ToString() => "Unit";
}

public static class Result
{
    public static Result<Unit> Success() => new SuccessResult();

    public static Result<T> Success<T>(T value) => new SuccessResult<T>(value);

    public static Result<Unit> Fail<TError>(TError error) => new FailedResult<Unit, TError>(error);

    public static Result<T> Fail<T, TError>(TError error) => new FailedResult<T, TError>(error);
}

public abstract record Result<T>
{
    public bool IsSuccess { get; protected init; }

    public bool IsError { get; protected init; }

    public static implicit operator Result<T>(T value) => Result.Success(value);
}

public record SuccessResult<T> : Result<T>
{
    public SuccessResult(T value)
    {
        Value = value;
        IsSuccess = true;
        IsError = false;
    }

    public T Value { get; }

    public static implicit operator T(SuccessResult<T> result) => result.Value;
}

public record SuccessResult() : Result<Unit>(Unit.Value);

public record FailedResult<T, TError> : Result<T>
{
    public FailedResult(TError error)
    {
        Error = error;
        IsSuccess = false;
        IsError = true;
    }

    public TError Error { get; }
}

public static class TypedResult
{
    public static Result<T> Fail<T>(string message) => new FailedResult<T, string>(message);

    public static Result<T> NotFound<T>(string? message = null) => new NotFoundResult<T>(message);

    public static Result<T> NotAuthorized<T>(string? message = null) => new NotAuthorizedResult<T>(message);

    public static Result<T> Conflict<T>(string message) => new ConflictResult<T>(message);
}

public sealed record NotFoundResult<T>(string? message = null) : FailedResult<T, string>(message ?? "Item not found");

public sealed record NotAuthorizedResult<T>(string? message = null) : FailedResult<T, string>(message ?? "Access not authorized");

public sealed record ConflictResult<T>(string message) : FailedResult<T, string>(message);