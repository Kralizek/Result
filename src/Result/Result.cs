namespace Result;

public abstract class Result
{
    public bool IsSuccess { get; protected init;}
    
    public bool IsError { get; protected init; }
}

public abstract class Result<T> : Result
{
    public static Result<T> Success(T value) => new SuccessResult<T>(value);

    public static Result Error(params Error[] errors) => new ErrorResult(errors);

    public static implicit operator Result<T>(T value) => Success(value);
}
