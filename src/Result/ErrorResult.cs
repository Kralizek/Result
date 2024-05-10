namespace Result;

public readonly record struct Error(string Message);

public class ErrorResult : Result
{
    public ErrorResult(params Error[] errors)
    {
        Errors = errors ?? [];
        IsSuccess = false;
        IsError = true;
    }

    public Error[] Errors { get; }
}
