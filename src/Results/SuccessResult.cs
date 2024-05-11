namespace Kralizek.Results;

public class SuccessResult<T> : Result<T>
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
